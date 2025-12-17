using Enterprise.Application.Helpers;
using Enterprise.Application.Interfaces.Common;
using FluentValidation;

namespace Enterprise.Application.Features.Accounts.Commands.ChangeUserName
{
    public class ChangeUserNameCommandValidator : AbstractValidator<ChangeUserNameCommand>
    {
        public ChangeUserNameCommandValidator(ITranslator translator)
        {
            RuleFor(x => x.UserName)
                .NotEmpty()
                .MinimumLength(4)
                .Matches(Regexs.UserName)
                .WithName(p => translator[nameof(p.UserName)]);

        }
    }
}
