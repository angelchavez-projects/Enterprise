using System.Collections.Generic;

namespace Enterprise.Application.Wrappers
{
    public class Result
    {
        public bool Success { get; set; }
        public List<Error> Errors { get; set; }

        public static Result Ok()
            => new() { Success = true };

        public static Result Failure()
            => new() { Success = false };

        public static Result Failure(Error error)
            => new() { Success = false, Errors = [error] };

        public static Result Failure(IEnumerable<Error> errors)
            => new() { Success = false, Errors = [.. errors] };

        public static implicit operator Result(Error error)
            => new() { Success = false, Errors = [error] };

        public static implicit operator Result(List<Error> errors)
            => new() { Success = false, Errors = errors };

        public Result AddError(Error error)
        {
            Errors ??= [];
            Errors.Add(error);
            Success = false;
            return this;
        }
    }

    public class Result<TData> : Result
    {
        public TData Data { get; set; }

        public static Result<TData> Ok(TData data)
            => new() { Success = true, Data = data };
        public new static Result<TData> Failure()
            => new() { Success = false };

        public new static Result<TData> Failure(Error error)
            => new() { Success = false, Errors = [error] };

        public new static Result<TData> Failure(IEnumerable<Error> errors)
            => new() { Success = false, Errors = [.. errors] };

        public static implicit operator Result<TData>(TData data)
            => new() { Success = true, Data = data };

        public static implicit operator Result<TData>(Error error)
            => new() { Success = false, Errors = [error] };

        public static implicit operator Result<TData>(List<Error> errors)
            => new() { Success = false, Errors = errors };
    }
}
