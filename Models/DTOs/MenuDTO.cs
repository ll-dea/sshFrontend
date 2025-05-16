﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SSH_FrontEnd.Models.DTOs
{
    public class MenuDTO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MenuId { get; set; }

        public string MenuName { get; set; }

        public decimal Price { get; set; }

        public int? CateringId { get; set; }

        public int? MenuTypeId { get; set; }
        
    }
}
