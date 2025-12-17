using Enterprise.Application.Interfaces.Common;
using Enterprise.Application.Wrappers;

namespace Enterprise.Application.Features.Prototypes.Commands.UpdatePrototype
{
    public class UpdatePrototypeCommand : IRequest<Result>
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
    }
}
