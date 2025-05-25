using Microsoft.AspNetCore.Identity;

namespace MVC_Core.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? Address { get; set; }
    }
}
