using Enterprise.Application.DTOs.Account.Requests;
using Enterprise.Application.DTOs.Account.Responses;
using Enterprise.Application.Wrappers;
using System.Threading.Tasks;

namespace Enterprise.Application.Interfaces.Identity
{
    public interface IGetUserServices
    {
        Task<PagedResponse<UserDto>> GetPagedUsers(GetAllUsersRequest model);
    }
}
