namespace Enterprise.Domain.Tasks.DTOs
{
    public class TaskDto(string name, string type, string? description, DateTime createdDateTime)
    {
        public string Name { get; } = name;
        public string Type { get; } = type;
        public string? Description { get; } = description;
        public DateTime CreatedDateTime { get; } = createdDateTime;
    }
}
