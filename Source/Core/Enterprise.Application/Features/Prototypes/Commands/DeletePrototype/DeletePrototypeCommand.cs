using Enterprise.Application.Interfaces.Common;
using Enterprise.Application.Wrappers;

namespace Enterprise.Application.Features.Prototypes.Commands.DeletePrototype
{
    public class DeletePrototypeCommand : IRequest<Result>
    {
        public long Id { get; set; }
    }
}
