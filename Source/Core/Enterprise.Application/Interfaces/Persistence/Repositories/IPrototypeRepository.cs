using Enterprise.Application.DTOs.Common;
using Enterprise.Domain.Prototypes.DTOs;
using Enterprise.Domain.Prototypes.Entities;

namespace Enterprise.Application.Interfaces.Persistence.Repositories
{
    public interface IPrototypeRepository : IGenericRepository<Prototype>
    {
        Task<PaginationResponseDto<PrototypeDto>> GetPagedListAsync(int pageNumber, int pageSize, string name);
    }
}
