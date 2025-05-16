﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SSH_FrontEnd.Models.DTOs
{
    public class PastryDTO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PastryId { get; set; }

        public string PastryName { get; set; }

        public decimal Price { get; set; }

        public int? ShopId { get; set; }

        public int? PastryTypeId { get; set; }

        
    }
}
