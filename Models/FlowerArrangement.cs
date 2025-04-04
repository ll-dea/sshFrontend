
using SSH_FrontEnd.Models;
using System;
using System.Collections.Generic;

namespace SSH_FrontEnd.Models;

public partial class FlowerArrangement
{
    public int FlowerArrangementId { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public decimal Price { get; set; }

    public int FloristId { get; set; }

    public int FlowerArrangementTypeId { get; set; }

    // Fusha për multi-tenancy
    public string TenantId { get; set; }

    public virtual Florist Florist { get; set; }

    public virtual FlowerArrangementType FlowerArrangementType { get; set; }
}