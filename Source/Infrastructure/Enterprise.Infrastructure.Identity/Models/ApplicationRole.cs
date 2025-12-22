using Microsoft.AspNetCore.Identity;

namespace Enterprise.Infrastructure.Identity.Models
{
    public class ApplicationRole(string name) : IdentityRole<Guid>(name)
    {
    }
}
