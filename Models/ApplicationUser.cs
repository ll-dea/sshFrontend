using Microsoft.AspNetCore.Identity;

namespace SSH_FrontEnd.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
    }
}
