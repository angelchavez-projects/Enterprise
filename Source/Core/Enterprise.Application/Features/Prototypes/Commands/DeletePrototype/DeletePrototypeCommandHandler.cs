using Enterprise.Application.Helpers;
using Enterprise.Application.Interfaces.Common;
using Enterprise.Application.Interfaces.Persistence;
using Enterprise.Application.Interfaces.Persistence.Repositories;
using Enterprise.Application.Wrappers;
using Enterprise.Application.Wrappers.Enums;

namespace Enterprise.Application.Features.Prototypes.Commands.DeletePrototype
{
    public class DeletePrototypeCommandHandler(IPrototypeRepository prototypeRepository, IUnitOfWork unitOfWork, ITranslator translator) : IRequestHandler<DeletePrototypeCommand, Result>
    {
        public async Task<Result> Handle(DeletePrototypeCommand request, CancellationToken cancellationToken = default)
        {
            var prototype = await prototypeRepository.GetByIdAsync(request.Id);

            if (prototype == null)
            {
                var message = TranslatorMessages.PrototypeMessages.Prototype_NotFound_with_id(request.Id);

                return new Error(ErrorCode.NotFound, translator.GetString(message.ToString()), nameof(request.Id));
            }

            prototypeRepository.Delete(prototype);
            await unitOfWork.SaveChangesAsync();

            return Result.Ok();
        }
    }
}
