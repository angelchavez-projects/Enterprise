using Enterprise.Application.Wrappers;
using Enterprise.Application.Wrappers.Enums;
using Enterprise.WebApi.Infrastructure.Extensions;

namespace Enterprise.WebApi.Endpoints.Docs
{
    public class DocEndpoint : EndpointGroupBase
    {
        public override void Map(RouteGroupBuilder builder)
        {
            builder.MapGet(GetErrorCodes);
        }

        Result<Dictionary<int, string>> GetErrorCodes()
            => Enum.GetValues<ErrorCode>().ToDictionary(t => (int)t, t => t.ToString());
    }
}
