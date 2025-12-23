using Enterprise.Application.Helpers;
using Enterprise.Application.Interfaces.Common;
using Enterprise.Application.Interfaces.Persistence;
using Enterprise.Application.Interfaces.Persistence.Repositories;
using Enterprise.Application.Wrappers;
using Enterprise.Application.Wrappers.Enums;
using System.Threading;
using System.Threading.Tasks;

namespace Enterprise.Application.Features.Prototypes.Commands.UpdatePrototype
{
    public class UpdatePrototypeCommandHandler(IPrototypeRepository prototypeRepository, IUnitOfWork unitOfWork, ITranslator translator) : IRequestHandler<UpdatePrototypeCommand, Result>
    {
        public async Task<Result> Handle(UpdatePrototypeCommand request, CancellationToken cancellationToken = default)
        {
            var prototype = await prototypeRepository.GetByIdAsync(request.Id);

            if (prototype == null)
            {
                var message = TranslatorMessages.PrototypeMessages.Prototype_NotFound_with_id(request.Id);

                return new Error(ErrorCode.NotFound, translator.GetString(message.ToString()), nameof(request.Id));
            }

            prototype.Update(request.Name, request.Type, request.Description);
            await unitOfWork.SaveChangesAsync();

            return Result.Ok();
        }
    }
}
