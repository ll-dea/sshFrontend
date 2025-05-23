using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace SSH_FrontEnd.Models.DTOs
{
    public class EventDTO
    {
        public int EventId { get; set; }

        public string EventName { get; set; }

        public string EventType { get; set; }

        public DateTime? EventDate { get; set; }

        
        public string ApplicationUserId { get; set; } 
    }
}
