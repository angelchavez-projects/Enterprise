using System.Collections.Generic;
using System.Threading.Tasks;

namespace Enterprise.Application.Interfaces.Persistence.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> AddAsync(T entity);
        void Delete(T entity);
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T> GetByIdAsync(object id);
        void Update(T entity);
    }
}
