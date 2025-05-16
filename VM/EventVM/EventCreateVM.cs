// ViewModels/EventCreateViewModel.cs
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        public int SelectedVenueId { get; set; }
        public int SelectedFloristId { get; set; }

        public IEnumerable<SelectListItem> Venues { get; set; }
        public IEnumerable<SelectListItem> Florists { get; set; }
    }
}