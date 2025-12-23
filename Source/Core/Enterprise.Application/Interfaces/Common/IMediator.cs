using System.Threading;
using System.Threading.Tasks;

namespace Enterprise.Application.Interfaces.Common
{
    public interface IMediator
    {
        Task<TResponse> Send<TRequest, TResponse>(TRequest request, CancellationToken cancellationToken = default) where TRequest : IRequest<TResponse>;
    }
}
