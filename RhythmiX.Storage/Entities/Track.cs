using Newtonsoft.Json;
using RhythmiX.Storage.Common;
using RhythmiX.Storage.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RhythmiX.Storage.Entities
{
    [Table("Tracks", Schema = "RhythmiX")]
    public class Track : BaseEntity
    {
        [Required]
        public long Id { get; set; }

        [Required]
        public long AlbumId { get; set; }

        [Required]
        public string AlbumName { get; set; }

        [Required]
        public long ArtistId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Duration { get; set; }

        [Required]
        public DateOnly ReleaseDate { get; set; }

        [Required]
        public string AlbumImage { get; set; }

        [Required]
        public string Image { get; set; }

        [Required]
        public string Audio { get; set; }

        [Required]
        public string AudioDownload { get; set; }

        [Required]
        public MusicInfoModel MusicInfo { get; set; }
    }
}
