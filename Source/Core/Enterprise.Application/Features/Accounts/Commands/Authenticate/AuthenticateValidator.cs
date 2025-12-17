using Enterprise.Application.Helpers;
using Enterprise.Application.Interfaces.Common;
using FluentValidation;

namespace Enterprise.Application.Features.Accounts.Commands.Authenticate
{
    public class AuthenticateValidator : AbstractValidator<AuthenticateCommand>
    {
        public AuthenticateValidator(ITranslator translator)
        {
            RuleFor(x => x.UserName)
                .NotEmpty()
                .WithName(p => translator[nameof(p.UserName)]);

            RuleFor(x => x.Password)
                .NotEmpty()
                .Matches(Regexs.Password)
                .WithName(p => translator[nameof(p.Password)]);
        }
    }
}
