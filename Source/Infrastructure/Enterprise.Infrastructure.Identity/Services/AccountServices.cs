using Enterprise.Application.DTOs.Account.Requests;
using Enterprise.Application.DTOs.Account.Responses;
using Enterprise.Application.Helpers;
using Enterprise.Application.Interfaces.Common;
using Enterprise.Application.Interfaces.Identity;
using Enterprise.Application.Wrappers;
using Enterprise.Application.Wrappers.Enums;
using Enterprise.Infrastructure.Identity.Models;
using Enterprise.Infrastructure.Identity.Settings;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Enterprise.Infrastructure.Identity.Services
{
    public class AccountServices(UserManager<ApplicationUser> userManager, IAuthenticatedUserService authenticatedUser, SignInManager<ApplicationUser> signInManager, JwtSettings jwtSettings, ITranslator translator) : IAccountServices
    {
        public async Task<Result> ChangePassword(ChangePasswordRequest model)
        {
            var user = await userManager.FindByIdAsync(authenticatedUser.UserId);

            var token = await userManager.GeneratePasswordResetTokenAsync(user!);
            var identityResult = await userManager.ResetPasswordAsync(user, token, model.Password);

            if (identityResult.Succeeded)
                return Result.Ok();

            return identityResult.Errors.Select(p => new Error(ErrorCode.ErrorInIdentity, p.Description)).ToList();
        }

        public async Task<Result> ChangeUserName(ChangeUserNameRequest model)
        {
            var user = await userManager.FindByIdAsync(authenticatedUser.UserId);

            user.UserName = model.UserName;

            var identityResult = await userManager.UpdateAsync(user);

            if (identityResult.Succeeded)
                return Result.Ok();

            return identityResult.Errors.Select(p => new Error(ErrorCode.ErrorInIdentity, p.Description)).ToList();
        }

        public async Task<Result<AuthenticationResponse>> Authenticate(AuthenticationRequest request)
        {
            var user = await userManager.FindByNameAsync(request.UserName);
            if (user == null)
            {
                var message = TranslatorMessages.AccountMessages.Account_NotFound_with_UserName(request.UserName);

                return new Error(ErrorCode.NotFound, translator.GetString(message.ToString()), nameof(request.UserName));
            }

            var signInResult = await signInManager.PasswordSignInAsync(user.UserName, request.Password, false, lockoutOnFailure: false);
            if (!signInResult.Succeeded)
            {
                return new Error(ErrorCode.FieldDataInvalid, translator.GetString(TranslatorMessages.AccountMessages.Invalid_password()), nameof(request.Password));
            }

            return await GetAuthenticationResponse(user);
        }

        public async Task<Result<AuthenticationResponse>> AuthenticateByUserName(string username)
        {
            var user = await userManager.FindByNameAsync(username);
            if (user == null)
            {
                var message = TranslatorMessages.AccountMessages.Account_NotFound_with_UserName(username);

                return new Error(ErrorCode.NotFound, translator.GetString(message.ToString()), nameof(username));
            }

            return await GetAuthenticationResponse(user);
        }

        public async Task<Result<string>> RegisterGhostAccount()
        {
            var user = new ApplicationUser()
            {
                UserName = GenerateRandomString(7)
            };

            var identityResult = await userManager.CreateAsync(user);

            if (identityResult.Succeeded)
                return user.UserName;

            return identityResult.Errors.Select(p => new Error(ErrorCode.ErrorInIdentity, p.Description)).ToList();

            string GenerateRandomString(int length)
            {
                const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
                var random = new Random();
                return new string([.. Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)])]);
            }
        }

        private async Task<AuthenticationResponse> GetAuthenticationResponse(ApplicationUser user)
        {
            await userManager.UpdateSecurityStampAsync(user);

            var jwToken = await GenerateJwtToken();

            var rolesList = await userManager.GetRolesAsync(user);

            return new AuthenticationResponse()
            {
                Id = user.Id.ToString(),
                JwToken = new JwtSecurityTokenHandler().WriteToken(jwToken),
                Email = user.Email,
                UserName = user.UserName,
                Roles = rolesList,
                IsVerified = user.EmailConfirmed,
            };

            async Task<JwtSecurityToken> GenerateJwtToken()
            {
                var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Key));
                var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

                return new JwtSecurityToken(
                    issuer: jwtSettings.Issuer,
                    audience: jwtSettings.Audience,
                    claims: (await signInManager.ClaimsFactory.CreateAsync(user)).Claims,
                    expires: DateTime.UtcNow.AddMinutes(jwtSettings.DurationInMinutes),
                    signingCredentials: signingCredentials);
            }
        }
    }
}
