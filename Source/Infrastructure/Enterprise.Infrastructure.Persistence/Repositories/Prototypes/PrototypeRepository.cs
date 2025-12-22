using Enterprise.Application.DTOs.Common;
using Enterprise.Application.Interfaces.Persistence.Repositories;
using Enterprise.Domain.Prototypes.DTOs;
using Enterprise.Domain.Prototypes.Entities;
using Enterprise.Infrastructure.Persistence.Contexts.Configurations;

namespace Enterprise.Infrastructure.Persistence.Repositories.Prototypes
{
    public class PrototypeRepository(ApplicationDbContext dbContext) : GenericRepository<Prototype>(dbContext), IPrototypeRepository
    {
        public async Task<PaginationResponseDto<PrototypeDto>> GetPagedListAsync(int pageNumber, int pageSize, string name)
        {
            var query = dbContext.Prototypes.OrderBy(p => p.Created).AsQueryable();

            if (!string.IsNullOrWhiteSpace(name))
            {
                query = query.Where(p => p.Name.Contains(name));
            }

            return await Paged(query.Select(p => new PrototypeDto(p)), pageNumber, pageSize);
        }
    }
}
