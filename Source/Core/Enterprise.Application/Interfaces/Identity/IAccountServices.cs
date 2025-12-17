using Enterprise.Application.DTOs.Account.Requests;
using Enterprise.Application.DTOs.Account.Responses;
using Enterprise.Application.Wrappers;

namespace Enterprise.Application.Interfaces.Identity
{
    public interface IAccountServices
    {
        Task<Result<string>> RegisterGhostAccount();
        Task<Result> ChangePassword(ChangePasswordRequest model);
        Task<Result> ChangeUserName(ChangeUserNameRequest model);
        Task<Result<AuthenticationResponse>> Authenticate(AuthenticationRequest request);
        Task<Result<AuthenticationResponse>> AuthenticateByUserName(string username);
    }
}
