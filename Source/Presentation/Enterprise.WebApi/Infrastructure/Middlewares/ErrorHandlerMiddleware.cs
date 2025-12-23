using Enterprise.Application.Wrappers;
using Enterprise.Application.Wrappers.Enums;
using FluentValidation;
using System.Net;
using System.Text.Json;

namespace Enterprise.WebApi.Infrastructure.Middlewares
{
    public class ErrorHandlerMiddleware(RequestDelegate next)
    {
        private readonly JsonSerializerOptions jsonSerializerOptions = new()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";
                var responseModel = Result.Failure();

                switch (error)
                {
                    case ValidationException e:
                        // validation error
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        foreach (var validationFailure in e.Errors)
                        {
                            responseModel.AddError(new Error(ErrorCode.ModelStateNotValid, validationFailure.ErrorMessage, validationFailure.PropertyName));
                        }
                        break;
                    case KeyNotFoundException e:
                        // not found error
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        responseModel.AddError(new Error(ErrorCode.NotFound, e.Message));
                        break;
                    default:
                        // unhandled error
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        responseModel.AddError(new Error(ErrorCode.Exception, error.Message));
                        break;
                }
                var result = JsonSerializer.Serialize(responseModel, jsonSerializerOptions);

                await response.WriteAsync(result);
            }
        }
    }
}

