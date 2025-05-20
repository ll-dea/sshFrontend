

using SSH_FrontEnd.Models.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSH_FrontEnd.Models;

public partial class PastryType: IHasIdAndName
{
    [Key]
    public int PastryTypeId { get; set; }
    public int Id => PastryTypeId;
    public string Name { get; set; }

    public virtual ICollection<Pastry> Pastries { get; set; } = new List<Pastry>();


}
