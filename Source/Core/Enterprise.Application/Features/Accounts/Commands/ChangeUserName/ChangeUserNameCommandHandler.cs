using Enterprise.Application.Interfaces.Common;
using Enterprise.Application.Interfaces.Identity;
using Enterprise.Application.Wrappers;
using System.Threading;
using System.Threading.Tasks;

namespace Enterprise.Application.Features.Accounts.Commands.ChangeUserName
{
    public class ChangeUserNameCommandHandler(IAccountServices accountServices) : IRequestHandler<ChangeUserNameCommand, Result>
    {
        public async Task<Result> Handle(ChangeUserNameCommand request, CancellationToken cancellationToken = default)
        {
            return await accountServices.ChangeUserName(request);
        }
    }
}
