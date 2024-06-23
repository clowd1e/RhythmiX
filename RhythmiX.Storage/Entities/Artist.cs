using RhythmiX.Storage.Common;
using RhythmiX.Storage.Entities.ManyToMany;
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

        public List<UserLikedArtists> UserLikedArtists { get; set; }
        public List<UserHistoryArtists> UserHistoryArtists { get; set; }

        protected Artist() { }
        public Artist(long apiId, string name, DateOnly joinDate, string website, string image)
        {
            ApiId = apiId;
            Name = name;
            JoinDate = joinDate;
            Website = website;
            Image = image;
        }
    }
}
