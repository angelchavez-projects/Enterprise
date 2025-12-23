using Enterprise.Application.Interfaces.Common;
using Enterprise.Application.Interfaces.Persistence;
using Enterprise.Application.Interfaces.Persistence.Repositories;
using Enterprise.Application.Wrappers;
using Enterprise.Domain.Prototypes.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Enterprise.Application.Features.Prototypes.Commands.CreatePrototype
{
    public class CreatePrototypeCommandHandler(IPrototypeRepository taskRepository, IUnitOfWork unitOfWork) : IRequestHandler<CreatePrototypeCommand, Result<long>>
    {
        public async Task<Result<long>> Handle(CreatePrototypeCommand request, CancellationToken cancellationToken = default)
        {
            var prototype = new Prototype(request.Name, request.Type, request.Description);

            await taskRepository.AddAsync(prototype);
            await unitOfWork.SaveChangesAsync();

            return prototype.Id;
        }
    }
}
