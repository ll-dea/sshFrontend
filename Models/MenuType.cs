
using SSH_FrontEnd.Models.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSH_FrontEnd.Models;

public partial class MenuType: IHasIdAndName
{
    [Key]
    public int MenuTypeId { get; set; }
    public int Id => MenuTypeId;
    public string Name { get; set; }

    public virtual ICollection<Menu> Menus { get; set; } = new List<Menu>();

 
}
