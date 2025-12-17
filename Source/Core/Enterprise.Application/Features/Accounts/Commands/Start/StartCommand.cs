using Enterprise.Application.DTOs.Account.Responses;
using Enterprise.Application.Interfaces.Common;
using Enterprise.Application.Wrappers;

namespace Enterprise.Application.Features.Accounts.Commands.Start
{
    public class StartCommand : IRequest<Result<AuthenticationResponse>>
    {
    }
}
