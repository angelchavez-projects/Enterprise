using Enterprise.Application.Parameters;

namespace Enterprise.Application.DTOs.Account.Requests
{
    public class GetAllUsersRequest : PaginationRequestParameter
    {
        public required string Name { get; set; }
    }
}
