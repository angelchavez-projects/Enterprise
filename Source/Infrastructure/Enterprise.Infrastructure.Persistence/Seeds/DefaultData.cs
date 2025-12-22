using Enterprise.Domain.Prototypes.Entities;
using Enterprise.Infrastructure.Persistence.Contexts.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Enterprise.Infrastructure.Persistence.Seeds
{
    public static class DefaultData
    {
        public static async Task SeedAsync(ApplicationDbContext applicationDbContext)
        {
            if (!await applicationDbContext.Prototypes.AnyAsync())
            {
                List<Prototype> prototypes = new()
                {
                    new Prototype ("Prototype 1","Type 1","Description for Prototype 1"),
                    new Prototype ("Prototype 2","Type 2","Description for Prototype 2"),
                    new Prototype ("Prototype 3","Type 3","Description for Prototype 3"),
                };

                await applicationDbContext.Prototypes.AddRangeAsync(prototypes);

                await applicationDbContext.SaveChangesAsync();
            }
        }
    }
}
