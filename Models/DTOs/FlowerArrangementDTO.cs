﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SSH_FrontEnd.Models.DTOs
{
    public class FlowerArrangementDTO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FlowerArrangementId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int FloristId { get; set; }

        public int FlowerArrangementTypeId { get; set; }

        // Fusha për multi-tenancy
        public string TenantId { get; set; }

        
    }
}
