
using SSH_FrontEnd.Models.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSH_FrontEnd.Models;
public partial class PartnerStatus:IHasIdAndName
{
    [Key]
    public int PartnerStatusId { get; set; }
    public int Id => PartnerStatusId;

    public string Name { get; set; }


    public virtual ICollection<Florist> Florists { get; set; } = new List<Florist>();



    public virtual ICollection<MusicProvider> MusicProviders { get; set; } = new List<MusicProvider>();

    public virtual ICollection<PastryShop> PastryShops { get; set; } = new List<PastryShop>();

    public virtual ICollection<VenueProvider> VenueProviders { get; set; } = new List<VenueProvider>();


}