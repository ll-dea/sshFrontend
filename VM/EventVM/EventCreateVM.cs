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

        public List<int> BookedPastryIds { get; set; } = new();
        public List<int> BookedMenuIds { get; set; } = new();
        public List<int> BookedVenueIds { get; set; } = new();
        public List<int> BookedFloristIds { get; set; } = new();
        public List<int> BookedMusicIds { get; set; } = new();
    }
}