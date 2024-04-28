﻿using RhythmiX.Storage.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RhythmiX.Storage.Entities
{
    [Table("Artists", Schema = "MusicDb")]
    public class Artist : BaseEntity
    {
        [Required]
        public long ApiId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateOnly JoinDate { get; set; }

        [Required]
        public string Website { get; set; }

        [Required]
        public string Image { get; set; }

        public List<User> LikedUsers { get; set; }
        public List<User> HistoryUsers { get; set; }
    }
}
