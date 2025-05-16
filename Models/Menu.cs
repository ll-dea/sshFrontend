﻿
using SSH_FrontEnd.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSH_FrontEnd.Models;

public partial class Menu
{
    [Key]
    public int MenuId { get; set; }

    public string MenuName { get; set; }

    public decimal Price { get; set; }

    public int? CateringId { get; set; }

    public int? MenuTypeId { get; set; }



    public virtual MenuType MenuType { get; set; }


}