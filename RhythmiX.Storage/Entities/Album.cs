using Newtonsoft.Json;
using RhythmiX.Storage.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RhythmiX.Storage.Entities
{
    [Table("Albums", Schema = "RhythmiX")]
    public class Album : BaseEntity
    {
        [Required]
        public long ApiId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateOnly ReleaseDate { get; set; }

        [Required]
        public long ArtistId { get; set; }

        [Required]
        public string ArtistName { get; set; }

        [Required]
        public string Image { get; set; }

        [Required]
        public string Zip { get; set; }
    }
}
