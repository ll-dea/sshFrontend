using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSH_FrontEnd.Models;

public partial class Guest
{
    [Key]
    public int GuestId { get; set; }

    public string GuestName { get; set; }

    public string GuestSecondName { get; set; }

    public string GuestSurname { get; set; }

    public int? GuestStatus { get; set; }

    public int? EventId { get; set; }

    public int? TableId { get; set; }

    public virtual Event Event { get; set; }


   


}