﻿
using SSH_FrontEnd.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSH_FrontEnd.Models;

public partial class MenuType
{
    [Key]
    public int MenuTypeId { get; set; }

    public string TypeName { get; set; }

    public virtual ICollection<Menu> Menus { get; set; } = new List<Menu>();

    // Fusha për multi-tenancy
    public string TenantId { get; set; }
}
