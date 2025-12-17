using Enterprise.Application.Interfaces.Common;
using Enterprise.Application.Wrappers;
using Enterprise.Domain.Prototypes.DTOs;

namespace Enterprise.Application.Features.Prototypes.Queries.GetPrototypeById
{
    public class GetPrototypeByIdQuery : IRequest<Result<PrototypeDto>>
    {
        public long Id { get; set; }
    }
}
