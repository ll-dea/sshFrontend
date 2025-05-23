using SSH_FrontEnd.Models.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSH_FrontEnd.Models
{
    public class Pastry : IHasIdAndName
    {
        [Key]
        public int PastryId { get; set; }
        public int Id => PastryId;

        [Required]
        public string Name { get; set; }

        [Range(0.0, double.MaxValue)]
        public decimal Price { get; set; }

        public int? ShopId { get; set; }

        public int? PastryTypeId { get; set; }

        public virtual PastryType PastryType { get; set; }  // ✅ Corrected
        public virtual PastryShop Shop { get; set; }
    }
}
