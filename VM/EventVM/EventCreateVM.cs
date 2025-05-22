using SSH_FrontEnd.Models.DTOs;
using System;
using System.Collections.Generic;

namespace SSH_FrontEnd.VM.EventVM
{
    public class EventCreateVM
    {
        public EventDTO Event { get; set; }

        public List<FloristDTO> Florists { get; set; }
        public List<PastryShopDTO> PastryShops { get; set; }
        public List<VenueProviderDTO> VenueProviders { get; set; }
        public List<MusicProviderDTO> MusicProviders { get; set; }
        public List<MenuDTO> Menus { get; set; }

        public List<int> BookedPastryShopIds { get; set; }
        public List<int> BookedMusicProviderIds { get; set; }
        public List<int> BookedVenueProviderIds { get; set; }
        public List<int> BookedFloristIds { get; set; }
    }
}