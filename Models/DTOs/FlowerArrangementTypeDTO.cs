﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SSH_FrontEnd.Models.DTOs
{
    public class FlowerArrangementTypeDTO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FlowerArrangementTypeId { get; set; }

        public string Name { get; set; }

      
        public string TenantId { get; set; }
    }
}
