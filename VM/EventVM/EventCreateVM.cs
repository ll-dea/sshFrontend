// ViewModels/EventCreateViewModel.cs
using Microsoft.AspNetCore.Mvc.Rendering;
using SSH_FrontEnd.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace SSH_FrontEnd.VM.EventVM
{
   

    public class EventCreateVM
    {
        [Required]
        public string EventName { get; set; }

        [Required]
        public string EventType { get; set; }

        [Required]
        public DateTime EventDate { get; set; }

        

        // Dropdown Lists
        public IEnumerable<SelectListItem> Venues { get; set; }
        public IEnumerable<SelectListItem> Florists { get; set; }
        public IEnumerable<SelectListItem> MusicProviders { get; set; }
       
        public IEnumerable<SelectListItem> Pastries { get; set; }
        public IEnumerable<SelectListItem> Menues { get; set; }
        public List<Florist> FloristItems { get; set; }
        public List<Menu> MenuItems { get; set; }
        public List<MusicProvider> MusicProviderItems { get; set; }
        public List<Venue> VenueItems { get; set; }
        public List<Pastry> PastryItems { get; set; }

    }

}