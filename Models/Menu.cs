

using SSH_FrontEnd.Models.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSH_FrontEnd.Models;

public partial class Menu 
{
    [Key]
    public int MenuId { get; set; }
    public int Id => MenuId;

    public string Chef_Name { get; set; }

    public decimal Price { get; set; }
    public string Email { get; set; }



    public int? MenuTypeId { get; set; }



    public virtual MenuType MenuType { get; set; }


}