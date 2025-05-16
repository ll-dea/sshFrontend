using System.ComponentModel.DataAnnotations;

namespace SSH_FrontEnd.Models.DTOs
{
    public class RoleDTO
    {
        [Key]
        public int RoleId { get; set; }
        public string RoleName { get; set; }
    }
}
