using RhythmiX.Storage.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RhythmiX.Storage.Entities
{
    [Table("Playlists", Schema = "RhythmiX")]
    public class Playlist : BaseEntity
    {
        [Required]
        public long Id { get; set; }
    }
}
