using Newtonsoft.Json;
using RhythmiX.Storage.Common;
using RhythmiX.Storage.Entities.ManyToMany;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RhythmiX.Storage.Entities
{
    [Table("Tracks", Schema = "MusicDb")]
    public class Track : BaseEntity
    {
        [Required]
        public long ApiId { get; set; }

        [Required]
        public long AlbumId { get; set; }

        [Required]
        public string AlbumName { get; set; }

        [Required]
        public long ArtistId { get; set; }
        [Required]
        public string ArtistName { get; set; }

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

        public List<UserLikedTracks> UserLikedTracks { get; set; }
        public List<UserHistoryTracks> UserHistoryTracks { get; set; }

        protected Track() { }

        public Track(long apiId, long albumId, string albumName, long artistId, string name, int duration, DateOnly releaseDate, string albumImage, string image, string audio, string audioDownload)
        {
            ApiId = apiId;
            AlbumId = albumId;
            AlbumName = albumName;
            ArtistId = artistId;
            Name = name;
            Duration = duration;
            ReleaseDate = releaseDate;
            AlbumImage = albumImage;
            Image = image;
            Audio = audio;
            AudioDownload = audioDownload;
        }
    }
}
