using System.Threading.Tasks;

namespace Enterprise.Application.Interfaces.Persistence
{
    public interface IUnitOfWork
    {
        Task<bool> SaveChangesAsync();
    }
}
