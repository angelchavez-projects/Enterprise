using Enterprise.Application.Helpers;
using Enterprise.Application.Interfaces.Common;
using Enterprise.Application.Interfaces.Persistence.Repositories;
using Enterprise.Application.Wrappers;
using Enterprise.Application.Wrappers.Enums;
using Enterprise.Domain.Prototypes.DTOs;

namespace Enterprise.Application.Features.Prototypes.Queries.GetPrototypeById
{
    public class GetPrototypeByIdHandler(IPrototypeRepository prototypeRepository, ITranslator translator) : IRequestHandler<GetPrototypeByIdQuery, Result<PrototypeDto>>
    {
        public async Task<Result<PrototypeDto>> Handle(GetPrototypeByIdQuery request, CancellationToken cancellationToken = default)
        {
            var prototype = await prototypeRepository.GetByIdAsync(request.Id);

            if (prototype == null)
            {
                var message = TranslatorMessages.PrototypeMessages.Prototype_NotFound_with_id(request.Id);

                return new Error(ErrorCode.NotFound, translator.GetString(message.ToString()), nameof(request.Id));
            }

            return new PrototypeDto(prototype);
        }
    }
}
