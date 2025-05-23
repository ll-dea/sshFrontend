using Microsoft.AspNetCore.Identity;
using SSH_FrontEnd.Models.DTOs;


namespace SSH_FrontEnd.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
    }
}
