using Enterprise.Application.Interfaces.Common;
using Enterprise.Application.Wrappers;

namespace Enterprise.Application.Features.Prototypes.Commands.CreatePrototype
{
    public class CreatePrototypeCommand : IRequest<Result<long>>
    {
        public string Name { get;  set; } 
        public string Type { get; set; }
        public string Description { get; set; } 
    }
}
