using Enterprise.Application.DTOs.Account.Requests;
using Enterprise.Application.DTOs.Account.Responses;
using Enterprise.Application.Interfaces.Common;
using Enterprise.Application.Wrappers;

namespace Enterprise.Application.Features.Accounts.Commands.Authenticate
{
    public class AuthenticateCommand : AuthenticationRequest, IRequest<Result<AuthenticationResponse>>
    {
    }
}
