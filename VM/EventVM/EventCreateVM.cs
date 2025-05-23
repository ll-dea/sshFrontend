using SSH_FrontEnd.Models;
using SSH_FrontEnd.Models.DTOs;
using System;
using System.Collections.Generic;

namespace SSH_FrontEnd.VM.EventVM
{
    public class EventCreateVM
    {
        public EventDTO Event { get; set; } = new EventDTO();
        public List<VenueProvider> Venues { get; set; } = new();
        public List<MusicProvider> MusicProviders { get; set; } = new();
        public List<Florist> Florists { get; set; } = new();
        public List<PastryShop> PastryShops { get; set; } = new();

        public int SelectedVenueId { get; set; }
        public int SelectedMusicProviderId { get; set; }
        public int SelectedFloristId { get; set; }
        public int SelectedPastryShopId { get; set; }
    }
}