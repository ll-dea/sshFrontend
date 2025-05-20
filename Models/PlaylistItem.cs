

using SSH_FrontEnd.Models.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSH_FrontEnd.Models;


public partial class PlaylistItem: IHasIdAndName
{
    [Key]
    public int PlaylistItemId { get; set; }
    public int Id => PlaylistItemId;


    public string Name { get; set; }



   
    public int MusicProviderId { get; set; }

  
    public string Length { get; set; }

  
 

    public virtual MusicProvider MusicProvider { get; set; }


}