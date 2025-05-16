using System.ComponentModel.DataAnnotations;

namespace SSH_FrontEnd.VM.EventVM
{
    public class AdminManageVenueViewModel
    {
        public int VenueId { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal? Price { get; set; }

        public string Address { get; set; }

        public int? VenueTypeId { get; set; }

        public int? VenueProviderId { get; set; }
    }
}
