
using SSH_FrontEnd.Models.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace SSH_FrontEnd.Models;

public partial class MenuOrder: IHasIdAndName
{
    [Key]
    public int MenuOrderId { get; set; }
    public int Id => MenuOrderId;

    public string Name { get; set; }

    public decimal OrderPrice { get; set; }

    public double AgencyFee { get; set; }

    public string Allergents { get; set; }

    public string IngreedientsForbiddenByReligion { get; set; }

    public string AdditionalRequests { get; set; }

    public int? EventId { get; set; }

    public int? OrderStatusId { get; set; }

    public virtual Event Event { get; set; }
    public virtual OrderStatus OrderStatus { get; set; }



}
