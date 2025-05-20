﻿using System.ComponentModel.DataAnnotations;
namespace SSH_FrontEnd.Models;

public partial class OrderStatus
{
    [Key]
    public int OrderStatusId { get; set; }

    public string OrderStatusName { get; set; }

    public virtual ICollection<FlowerArrangementOrder> FlowerArrangementOrders { get; set; } = new List<FlowerArrangementOrder>();



    public virtual ICollection<MenuOrder> MenuOrders { get; set; } = new List<MenuOrder>();

    public virtual ICollection<MusicProviderOrder> MusicProviderOrders { get; set; } = new List<MusicProviderOrder>();

    public virtual ICollection<PastryOrder> PastryOrders { get; set; } = new List<PastryOrder>();

    public virtual ICollection<VenueOrder> VenueOrders { get; set; } = new List<VenueOrder>();


}