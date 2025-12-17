using Enterprise.Domain.Common.Auditable;

namespace Enterprise.Domain.Tasks.Entities
{
    public class Task(string name, string type, string? description) : AuditableEntity
    {
        public string Name { get; private set; } = name;
        public string Type { get; private set; } = type;
        public string? Description { get; private set; } = description;

        public void Update(string name, string type, string? description)
        {
            Name = name;
            Type = type;
            Description = description;
        }
    }
}
