using SSH_FrontEnd.Models.Common;
using System;
using System.Collections.Generic;

namespace SSH_FrontEnd.Models;

public partial class VenueType :IHasIdAndName
{
    public int VenueTypeId { get; set; }
    public int Id => VenueTypeId;
    public string Name { get; set; }

    public virtual ICollection<Venue> Venues { get; set; } = new List<Venue>();

}