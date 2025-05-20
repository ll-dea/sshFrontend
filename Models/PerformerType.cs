

using SSH_FrontEnd.Models.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SSH_FrontEnd.Models;
public partial class PerformerType : IHasIdAndName
{
    [Key]
    public int PerformerTypeId { get; set; }
    public int Id => PerformerTypeId;

    public string Name { get; set; }

    public virtual ICollection<MusicProvider> MusicProviders { get; set; } = new List<MusicProvider>();


}
