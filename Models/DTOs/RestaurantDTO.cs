﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SSH_FrontEnd.Models.DTOs
{
    public class RestaurantDTO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RestaurantId { get; set; } 
        public string RestaurantName { get; set; } 
        public string Address { get; set; } 
        public string PhoneNumber { get; set; } 
        public int? RestaurantStatusId { get; set; } 

 
        

       
        public int VenueId { get; set; } 

       
    }
}
