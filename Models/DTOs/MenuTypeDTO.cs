using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SSH_FrontEnd.Models.DTOs
{
    public class MenuTypeDTO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MenuTypeId { get; set; }

        public string TypeName { get; set; }

      
       
    }
}
