using System;
using System.Collections.Generic;
namespace SSH_FrontEnd.VM.EventVM
{
    public class MyEventsViewModel
    {
        public int EventId { get; set; }
        public string EventName { get; set; }
        public string EventType { get; set; }
        public DateTime? EventDate { get; set; }
        public string VenueName { get; set; }
        public string Status { get; set; }
        public string? ApplicationUserId { get;  set; }
    }
}
