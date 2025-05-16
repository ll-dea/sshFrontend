﻿
using SSH_FrontEnd.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSH_FrontEnd.Models;

public partial class PastryType
{
    [Key]
    public int PastryTypeId { get; set; }

    public string TypeName { get; set; }

    public virtual ICollection<Pastry> Pastries { get; set; } = new List<Pastry>();


}
