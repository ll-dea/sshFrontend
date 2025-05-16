﻿
using SSH_FrontEnd.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSH_FrontEnd.Models;

public partial class Pastry
{
    [Key]
    public int PastryId { get; set; }

    public string PastryName { get; set; }

    public decimal Price { get; set; }

    public int? ShopId { get; set; }

    public int? PastryTypeId { get; set; }

    public virtual PastryType PastryType { get; set; }

    public virtual PastryShop Shop { get; set; }

}
