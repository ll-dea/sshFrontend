using Microsoft.AspNetCore.Identity;
using NLog.Web.LayoutRenderers;
using System;
using SSH_FrontEnd.Models;

namespace SSH_FrontEnd.Models
{
    public class Users : IdentityUser
    {
        private int UserId { get; set; }
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string ProfilePictureUrl { get; set; }

        // Fusha për multi-tenancy
        public string TenantId { get; set; }

    }
}
