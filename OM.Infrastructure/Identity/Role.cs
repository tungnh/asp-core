using Microsoft.AspNetCore.Identity;

namespace OM.Infrastructure.Identity
{
    public class Role : IdentityRole<int>
    {
        public string? Description { get; set; }
    }
}
