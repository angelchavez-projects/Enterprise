using Enterprise.Application.Interfaces.Common;
using FluentValidation;

namespace Enterprise.Application.Features.Prototypes.Commands.UpdatePrototype
{
    public class UpdatePrototypeCommandValidator : AbstractValidator<UpdatePrototypeCommand>
    {
        public UpdatePrototypeCommandValidator(ITranslator translator)
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .MaximumLength(100)
                .WithName(p => translator[nameof(p.Name)]);

            RuleFor(x => x.Type)
                .NotEmpty()
                .MaximumLength(50)
                .WithName(p => translator[nameof(p.Type)]);
        }
    }
}
