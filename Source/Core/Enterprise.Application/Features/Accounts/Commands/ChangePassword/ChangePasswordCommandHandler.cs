using Enterprise.Application.Interfaces.Common;
using Enterprise.Application.Interfaces.Identity;
using Enterprise.Application.Wrappers;
using System.Threading;
using System.Threading.Tasks;

namespace Enterprise.Application.Features.Accounts.Commands.ChangePassword
{
    public class ChangePasswordCommandHandler(IAccountServices accountServices) : IRequestHandler<ChangePasswordCommand, Result>
    {
        public async Task<Result> Handle(ChangePasswordCommand request, CancellationToken cancellationToken = default)
        {
            return await accountServices.ChangePassword(request);
        }
    }
}
