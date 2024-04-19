﻿using RhythmiX.Storage.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RhythmiX.Storage.Entities
{
    [Table("Tracks", Schema = "RhythmiX")]
    public class Track : BaseEntity
    {
        [Required]
        public long Id { get; set; }
    }
}
