using Enterprise.Application.Interfaces.Identity;
using Enterprise.Domain.Prototypes.Entities;
using Enterprise.Infrastructure.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Enterprise.Infrastructure.Persistence.Contexts.Configurations
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IAuthenticatedUserService authenticatedUser) : DbContext(options)
    {
        public DbSet<Prototype> Prototypes { get; set; }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
        {
            ChangeTracker.ApplyAuditing(authenticatedUser);

            return base.SaveChangesAsync(cancellationToken);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            this.ConfigureDecimalProperties(builder);

            base.OnModelCreating(builder);
        }
    }
}
