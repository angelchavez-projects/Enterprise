using Enterprise.Application.DTOs.Account.Responses;
using Enterprise.Application.Wrappers;

namespace Enterprise.Application.Interfaces.Identity
{
    public interface IGetUserService
    {
        Task<PagedResponse<UserDto>> GetPagedUsers();
    }
}
