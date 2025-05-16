using System.ComponentModel.DataAnnotations;

namespace SSH_FrontEnd.Models.DTOs
{
    public class PerformerTypeDTO
    {
        [Key]
        public int PerformerTypeId { get; set; }

        public string Name { get; set; }


        
    }
}
