using Enterprise.Application.DTOs.Account.Responses;
using Enterprise.Application.Interfaces.Common;
using Enterprise.Application.Interfaces.Identity;
using Enterprise.Application.Wrappers;
using System.Threading;
using System.Threading.Tasks;

namespace Enterprise.Application.Features.Accounts.Commands.Start
{
    public class StartCommandHandler(IAccountServices accountServices) : IRequestHandler<StartCommand, Result<AuthenticationResponse>>
    {
        public async Task<Result<AuthenticationResponse>> Handle(StartCommand request, CancellationToken cancellationToken = default)
        {
            var ghostUsernameResult = await accountServices.RegisterGhostAccount();

            if (!ghostUsernameResult.Success || ghostUsernameResult.Data is null)
                return Result<AuthenticationResponse>.Failure(ghostUsernameResult.Errors ?? []);

            return await accountServices.AuthenticateByUserName(ghostUsernameResult.Data);
        }
    }
}
