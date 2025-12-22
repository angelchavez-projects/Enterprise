using Enterprise.Domain.Prototypes.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Enterprise.Infrastructure.Persistence.Contexts.Configurations.Prototypes
{
    public class PrototypeConfiguration : IEntityTypeConfiguration<Prototype>
    {
        public void Configure(EntityTypeBuilder<Prototype> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(p => p.Name).HasMaxLength(100);
            builder.Property(p => p.Type).HasMaxLength(50);
            builder.Property(p => p.Description).HasMaxLength(50);
        }
    }
}
