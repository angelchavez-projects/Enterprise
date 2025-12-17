using Enterprise.Application.DTOs.Account.Requests;
using Enterprise.Application.Interfaces.Common;
using Enterprise.Application.Wrappers;

namespace Enterprise.Application.Features.Accounts.Commands.ChangePassword
{
    public class ChangePasswordCommand : ChangePasswordRequest, IRequest<Result>
    {
    }
}
