using SSH_FrontEnd.Models.Common;
using System;
using System.Collections.Generic;

namespace SSH_FrontEnd.Models;

public partial class VenueOrder: IHasIdAndName
{
    public int VenueOrderId { get; set; }

    public int VenueId { get; set; }
    public int Id => VenueOrderId;

    public string Name { get; set; }

    public string Description { get; set; }

    public decimal? Price { get; set; }

    public string Address { get; set; }

    public decimal? AgencyFee { get; set; }

    public string Notes { get; set; }

    public int? EventId { get; set; }

    public int? OrderStatusId { get; set; }

    public virtual Event Event { get; set; }

    public virtual OrderStatus OrderStatus { get; set; }

    public virtual Venue Venue { get; set; }

 
}