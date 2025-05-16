﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SSH_FrontEnd.Models.DTOs
{
    public class PlaylistItemDTO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PlaylistItemId { get; set; }


        public string Name { get; set; }

        public int GenreId { get; set; }


        public int MusicProviderId { get; set; }


        public string Length { get; set; }

       
    }
}
