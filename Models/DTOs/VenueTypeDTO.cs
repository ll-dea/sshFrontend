using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SSH_FrontEnd.Models.DTOs
{
    public class VenueTypeDTO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int VenueTypeId { get; set; }

        public string Name { get; set; }


       
    }
}
