using Enterprise.Application.Features.Prototypes.Commands.CreatePrototype;
using Enterprise.Application.Features.Prototypes.Commands.DeletePrototype;
using Enterprise.Application.Features.Prototypes.Commands.UpdatePrototype;
using Enterprise.Application.Features.Prototypes.Queries.GetPagedListPrototype;
using Enterprise.Application.Features.Prototypes.Queries.GetPrototypeById;
using Enterprise.Application.Interfaces.Common;
using Enterprise.Application.Wrappers;
using Enterprise.Domain.Prototypes.DTOs;
using Enterprise.WebApi.Infrastructure.Extensions;

namespace Enterprise.WebApi.Endpoints.Prototypes
{
    public class PrototypeEndpoint : EndpointGroupBase
    {
        public override void Map(RouteGroupBuilder builder)
        {
            builder.MapGet(GetPagedListPrototype);

            builder.MapGet(GetPrototypeById);

            builder.MapPost(CreatePrototype).RequireAuthorization();

            builder.MapPut(UpdatePrototype).RequireAuthorization();

            builder.MapDelete(DeletePrototype).RequireAuthorization();
        }

        async Task<PagedResponse<PrototypeDto>> GetPagedListPrototype(IMediator mediator, [AsParameters] GetPagedListPrototypeQuery model)
    => await mediator.Send<GetPagedListPrototypeQuery, PagedResponse<PrototypeDto>>(model);

        async Task<Result<PrototypeDto>> GetPrototypeById(IMediator mediator, [AsParameters] GetPrototypeByIdQuery model)
            => await mediator.Send<GetPrototypeByIdQuery, Result<PrototypeDto>>(model);

        async Task<Result<long>> CreatePrototype(IMediator mediator, CreatePrototypeCommand model)
            => await mediator.Send<CreatePrototypeCommand, Result<long>>(model);

        async Task<Result> UpdatePrototype(IMediator mediator, UpdatePrototypeCommand model)
            => await mediator.Send<UpdatePrototypeCommand, Result>(model);

        async Task<Result> DeletePrototype(IMediator mediator, [AsParameters] DeletePrototypeCommand model)
            => await mediator.Send<DeletePrototypeCommand, Result>(model);
    }
}
