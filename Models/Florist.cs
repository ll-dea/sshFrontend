using SSH_FrontEnd.Models;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SSH_FrontEnd.Models.Common;

namespace SSH_FrontEnd.Models;

public  class Florist : IHasIdAndName
{
    [Key]
    public int FloristId { get; set; }

    public string Name { get; set; }

    public string Address { get; set; }

    public string PhoneNumber { get; set; }

    public string Email { get; set; }

    public decimal? AgencyFee { get; set; }

    public int? PartnerStatusId { get; set; }
    public int Id => FloristId;



    public virtual ICollection<FlowerArrangement> FlowerArrangements { get; set; } = new List<FlowerArrangement>();

    public virtual PartnerStatus PartnerStatus { get; set; }
}
