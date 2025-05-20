

using SSH_FrontEnd.Models.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace SSH_FrontEnd.Models;

public partial class PastryShop:IHasIdAndName
{
    [Key]
    public int ShopId { get; set; }
    public int Id => ShopId;

    public string Name { get; set; }

    public string Address { get; set; }

    public string PhoneNumber { get; set; }

    public int? PartnerStatusId { get; set; }

    public virtual PartnerStatus PartnerStatus { get; set; }

    public virtual ICollection<Pastry> Pastries { get; set; } = new List<Pastry>();


}