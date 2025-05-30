﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SSH_FrontEnd.Models.DTOs
{
    public class FloristDTO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FloristId { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public decimal? AgencyFee { get; set; }

        public int? PartnerStatusId { get; set; }
        //public List<string> FlowerArrangementTypes { get; set; }
        //public List<FlowerArrangementDTO> FlowerArrangements { get; set; } // ✅ Needed



    }
}
