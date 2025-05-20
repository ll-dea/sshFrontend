
using SSH_FrontEnd.Models.Common;
using System;
using System.Collections.Generic;

namespace SSH_FrontEnd.Models;

public partial class VenueProvider: IHasIdAndName
{
    public int VenueProviderId { get; set; }
    public int Id => VenueProviderId;

    public string Name { get; set; }

    public string Address { get; set; }

    public string PhoneNumber { get; set; }

    public string Email { get; set; }

    public decimal? AgencyFee { get; set; }

    public int? PartnerStatusId { get; set; }

    public virtual PartnerStatus PartnerStatus { get; set; }

    public virtual ICollection<Venue> Venues { get; set; } = new List<Venue>();

   
}