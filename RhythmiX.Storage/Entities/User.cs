using RhythmiX.Storage.Common;
using RhythmiX.Storage.Models.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RhythmiX.Storage.Entities
{
    [Table("Users", Schema = "MusicDb")]
    public class User : BaseEntity
    {
        public User(string username, string password, string email)
        {
            Username = username;
            Password = password;
            Email = email;
        }

        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string Username { get; set; }

        [Required]
        [MinLength(8)]
        [MaxLength(30)]
        public string Password { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        

        public List<Track> LikedTracks { get; set; }
        public List<Album> LikedAlbums { get; set; }
        public List<Playlist> LikedPlaylists { get; set; }
        public List<Artist> LikedArtists { get; set; }
        public List<IHistoryObservable> History { get; set; }
    }
}
