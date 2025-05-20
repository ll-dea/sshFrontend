
using SSH_FrontEnd.Models.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace SSH_FrontEnd.Models;

public partial class OrderStatus: IHasIdAndName
{
    [Key]
    public int OrderStatusId { get; set; }
    public int Id => OrderStatusId;
    public string Name { get; set; }

    public virtual ICollection<FlowerArrangementOrder> FlowerArrangementOrders { get; set; } = new List<FlowerArrangementOrder>();

 

    public virtual ICollection<MenuOrder> MenuOrders { get; set; } = new List<MenuOrder>();

    public virtual ICollection<MusicProviderOrder> MusicProviderOrders { get; set; } = new List<MusicProviderOrder>();

    public virtual ICollection<PastryOrder> PastryOrders { get; set; } = new List<PastryOrder>();

    public virtual ICollection<VenueOrder> VenueOrders { get; set; } = new List<VenueOrder>();


}