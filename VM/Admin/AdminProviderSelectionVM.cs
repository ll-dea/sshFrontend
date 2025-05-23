using SSH_FrontEnd.Models.DTOs;
using System.Collections.Generic;

namespace SSH_FrontEnd.VM.Admin
{
    public class AdminProviderSelectionVM
    {
        public List<PastryShopDTO> PastryShops { get; set; }
        public List<FloristDTO> Florists { get; set; }
        public List<MusicProviderDTO> MusicProviders { get; set; }
        public List<VenueProviderDTO> VenueProviders { get; set; }
        public List<MenuDTO> Menus { get; set; }

        public int SelectedPastryShopId { get; set; }
        public int SelectedFloristId { get; set; }
        public int SelectedMusicProviderId { get; set; }
        public int SelectedVenueProviderId { get; set; }
        public int SelectedMenuId { get; set; }
    }
}
