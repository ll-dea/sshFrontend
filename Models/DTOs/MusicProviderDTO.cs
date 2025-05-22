﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SSH_FrontEnd.Models.DTOs
{
    public class MusicProviderDTO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MusicProviderId { get; set; }


        public string Name { get; set; }


        public string Address { get; set; }


        public string PhoneNumber { get; set; }


        public string Email { get; set; }


        public decimal? AgencyFee { get; set; }


        public int? PerformerTypeId { get; set; }


        public int? PartnerStatusId { get; set; }


        public decimal? BaseHourlyRate { get; set; }

        public List<PlaylistItemDTO> PlaylistItems { get; set; } // ✅ Needed



    }
}
