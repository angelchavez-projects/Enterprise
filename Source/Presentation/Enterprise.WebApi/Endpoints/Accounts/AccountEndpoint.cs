using Enterprise.Application.DTOs.Account.Responses;
using Enterprise.Application.Features.Accounts.Commands.Authenticate;
using Enterprise.Application.Features.Accounts.Commands.ChangePassword;
using Enterprise.Application.Features.Accounts.Commands.ChangeUserName;
using Enterprise.Application.Features.Accounts.Commands.Start;
using Enterprise.Application.Interfaces.Common;
using Enterprise.Application.Wrappers;
using Enterprise.WebApi.Infrastructure.Extensions;

namespace Enterprise.WebApi.Endpoints.Accounts
{
    public class AccountEndpoint : EndpointGroupBase
    {
        public override void Map(RouteGroupBuilder builder)
        {
            builder.MapPost(Authenticate);

            builder.MapPut(ChangeUserName).RequireAuthorization();

            builder.MapPut(ChangePassword).RequireAuthorization();

            builder.MapPost(Start);
        }


        async Task<Result<AuthenticationResponse>> Authenticate(IMediator mediator, AuthenticateCommand model)
            => await mediator.Send<AuthenticateCommand, Result<AuthenticationResponse>>(model);

        async Task<Result> ChangeUserName(IMediator mediator, ChangeUserNameCommand model)
            => await mediator.Send<ChangeUserNameCommand, Result>(model);

        async Task<Result> ChangePassword(IMediator mediator, ChangePasswordCommand model)
            => await mediator.Send<ChangePasswordCommand, Result>(model);

        async Task<Result<AuthenticationResponse>> Start(IMediator mediator)
            => await mediator.Send<StartCommand, Result<AuthenticationResponse>>(new StartCommand());
    }
}
