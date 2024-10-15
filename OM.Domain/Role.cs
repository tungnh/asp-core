using Microsoft.AspNetCore.Identity;

namespace OM.Domain
{
    public class Role : IdentityRole<int>
    {
        public string? Description { get; set; }
    }
}
