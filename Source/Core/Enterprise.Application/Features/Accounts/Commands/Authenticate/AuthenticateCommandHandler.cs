using Enterprise.Application.DTOs.Account.Responses;
using Enterprise.Application.Interfaces.Common;
using Enterprise.Application.Interfaces.Identity;
using Enterprise.Application.Wrappers;
using System.Threading;
using System.Threading.Tasks;

namespace Enterprise.Application.Features.Accounts.Commands.Authenticate
{
    public class AuthenticateCommandHandler(IAccountServices accountServices) : IRequestHandler<AuthenticateCommand, Result<AuthenticationResponse>>
    {
        public async Task<Result<AuthenticationResponse>>Handle(AuthenticateCommand request, CancellationToken cancellationToken = default)
        {
            return await accountServices.Authenticate(request);
        }
    }
}
