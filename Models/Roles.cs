using System.ComponentModel.DataAnnotations;

namespace SSH_FrontEnd.Models
{
    public class Roles
    {
        [Key]
        public int RoleId { get; set; }
        public string RoleName { get; set; }
    }
}
