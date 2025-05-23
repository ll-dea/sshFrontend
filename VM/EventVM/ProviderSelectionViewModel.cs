using SSH_FrontEnd.Models;
using System.Collections.Generic;

namespace SSH_FrontEnd.Models.ViewModels
{
    public class ProviderSelectionViewModel
    {
        public int EventId { get; set; }

        public int SelectedVenueId { get; set; }
        public int SelectedMusicProviderId { get; set; }
        public int SelectedMenuId { get; set; }
        public int SelectedFloristId { get; set; }
        public int SelectedPastryShopId { get; set; }

        public List<VenueProvider> Venues { get; set; }
        public List<MusicProvider> MusicProviders { get; set; }
        public List<Menu> Menus { get; set; }
        public List<Florist> Florists { get; set; }
        public List<PastryShop> PastryShops { get; set; }
    }
}
