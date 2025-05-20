
using SSH_FrontEnd.Models.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace SSH_FrontEnd.Models;


public partial class MusicProvider : IHasIdAndName
{
    [Key]
    public int MusicProviderId { get; set; }

    public int Id => MusicProviderId;
    public string Name { get; set; }

   
    public string Address { get; set; }

  
    public string PhoneNumber { get; set; }

    
    public string Email { get; set; }

    
    public decimal? AgencyFee { get; set; }


    public int? PerformerTypeId { get; set; }

  
    public int? PartnerStatusId { get; set; }

  
    public decimal? BaseHourlyRate { get; set; }


    public virtual PartnerStatus PartnerStatus { get; set; }

    public virtual PerformerType PerformerType { get; set; }

   
    public virtual ICollection<PlaylistItem> PlaylistItems { get; set; } = new List<PlaylistItem>();


}