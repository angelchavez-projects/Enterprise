using Enterprise.Domain.Prototypes.Entities;

namespace Enterprise.Domain.Prototypes.DTOs
{
    public class PrototypeDto
    {
        public PrototypeDto()
        {
            
        }

        public long Id { get; set; }
        public string Name { get; set; } 
        public string Type { get; set; } 
        public string Description { get; set; }
        public DateTime CreatedDateTime { get; set; }
        
        public PrototypeDto(Prototype prototype)
        {
            Id = prototype.Id;
            Name = prototype.Name;
            Type = prototype.Type;
            Description = prototype.Description;
            CreatedDateTime = prototype.Created;
        }
    }
}
