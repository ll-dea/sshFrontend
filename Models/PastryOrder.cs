﻿

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSH_FrontEnd.Models;

public partial class PastryOrder
{
    [Key]
    public int PastryOrderId { get; set; }

    public string OrderName { get; set; }

    public decimal OrderPrice { get; set; }

    public double AgencyFee { get; set; }

    public string OrderDescription { get; set; }

    public string Notes { get; set; }

    public int? EventId { get; set; }

    public int? OrderStatusId { get; set; }

    public virtual Event Event { get; set; }

    public virtual OrderStatus OrderStatus { get; set; }


}