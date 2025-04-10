﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SSH_FrontEnd.Models.DTOs
{
    public class FlowerArrangementOrderDTO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FlowerArrangementOrderId { get; set; }

        public string OrderName { get; set; }

        public decimal OrderPrice { get; set; }

        public double AgencyFee { get; set; }

        public string OrderDescription { get; set; }

        public string Notes { get; set; }

        public int? EventId { get; set; }

        public int? OrderStatusId { get; set; }

        // Fusha për multi-tenancy
        public string TenantId { get; set; }
    }
}
