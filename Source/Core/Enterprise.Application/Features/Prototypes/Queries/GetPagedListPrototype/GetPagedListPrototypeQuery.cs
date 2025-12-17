using Enterprise.Application.Interfaces.Common;
using Enterprise.Application.Parameters;
using Enterprise.Application.Wrappers;
using Enterprise.Domain.Prototypes.DTOs;

namespace Enterprise.Application.Features.Prototypes.Queries.GetPagedListPrototype
{
    public class GetPagedListPrototypeQuery : PaginationRequestParameter, IRequest<PagedResponse<PrototypeDto>>
    {
        public string Name { get; set; }
    }
}
