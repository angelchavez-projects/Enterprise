using Enterprise.Application.Interfaces.Common;
using Enterprise.Application.Interfaces.Persistence.Repositories;
using Enterprise.Application.Wrappers;
using Enterprise.Domain.Prototypes.DTOs;

namespace Enterprise.Application.Features.Prototypes.Queries.GetPagedListPrototype
{
    public class GetPagedListPrototypeQueryHandler(IPrototypeRepository PrototypeRepository) : IRequestHandler<GetPagedListPrototypeQuery, PagedResponse<PrototypeDto>>
    {
        public async Task<PagedResponse<PrototypeDto>> Handle(GetPagedListPrototypeQuery request, CancellationToken cancellationToken)
        {
            return await PrototypeRepository.GetPagedListAsync(request.PageNumber, request.PageSize, request.Name);
        }
    }
}
