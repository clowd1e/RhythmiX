using Newtonsoft.Json;
using RhythmiX.Storage.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RhythmiX.Storage.Entities
{
    [Table("Albums", Schema = "MusicDb")]
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


        public List<User> LikedUsers { get; set; }
        public List<User> HistoryUsers { get; set; }

        public Album(long apiId, string name, DateOnly releaseDate, long artistId, string artistName, string image, string zip)
        {
            ApiId = apiId;
            Name = name;
            ReleaseDate = releaseDate;
            ArtistId = artistId;
            ArtistName = artistName;
            Image = image;
            Zip = zip;
        }
    }
}
