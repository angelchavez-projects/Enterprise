using Enterprise.Application.DTOs.Common;

namespace Enterprise.Application.Wrappers
{
    public class PagedResponse<T> : Result<List<T>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public int TotalItems { get; set; }

        public static PagedResponse<T> Ok(PaginationResponseDto<T> response)
        {
            return new PagedResponse<T>
            {
                Success = true,
                Data = response.Data,
                PageNumber = response.PageNumber,
                PageSize = response.PageSize,
                TotalItems = response.Count,
                TotalPages = (int)Math.Ceiling(response.Count / (double)response.PageSize),
            };
        }

        public new static PagedResponse<T> Failure(Error error)
            => new() { Success = false, Errors = [error] };

        public new static PagedResponse<T> Failure(IEnumerable<Error> errors)
            => new() { Success = false, Errors = [.. errors] };

        public static implicit operator PagedResponse<T>(PaginationResponseDto<T> model)
            => Ok(model);

        public static implicit operator PagedResponse<T>(Error error)
            => new() { Success = false, Errors = [error] };

        public static implicit operator PagedResponse<T>(List<Error> errors)
            => new() { Success = false, Errors = errors };
    }
}
