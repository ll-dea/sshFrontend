using System;
using System.Collections.Generic;
using SSH_FrontEnd.Models;
using SSH_FrontEnd.Models.Common;

namespace SSH_FrontEnd.Models;

public partial class Venue : IHasIdAndName
{
    public int VenueId { get; set; }
    public int Id => VenueId;


    public string Name { get; set; }

    public string Description { get; set; }

    public decimal? Price { get; set; }

    public string Address { get; set; }

    public int? VenueProviderId { get; set; }

    public int? VenueTypeId { get; set; }

    public virtual ICollection<Table> Tables { get; set; } = new List<Table>();

    public virtual ICollection<VenueOrder> VenueOrders { get; set; } = new List<VenueOrder>();

    public virtual VenueProvider VenueProvider { get; set; }
    public virtual ICollection<Restaurant> Restaurant { get; set; } = new List<Restaurant>();
    public virtual VenueType VenueType { get; set; }

  
}