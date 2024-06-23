using RhythmiX.Storage.Common;
using RhythmiX.Storage.Entities.ManyToMany;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RhythmiX.Storage.Entities
{
    [Table("Users", Schema = "MusicDb")]
    public class User : BaseEntity
    {
        protected User() { }
        public User(string username, string password, string email)
        {
            Username = username;
            Password = password;
            Email = email;
        }

        public User(string username, string password)
        {
            Username = username;
            Password = password;
        }

        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string Username { get; set; }

        [Required]
        [MinLength(8)]
        [MaxLength(100)]
        public string Password { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        

        public List<UserLikedTracks> UserLikedTracks { get; set; }
        public List<UserLikedAlbums> UserLikedAlbums { get; set; }
        public List<UserLikedPlaylists> UserLikedPlaylists { get; set; }
        public List<UserLikedArtists> UserLikedArtists { get; set; }
        public List<UserHistoryTracks> UserHistoryTracks { get; set; }
        public List<UserHistoryAlbums> UserHistoryAlbums { get; set; }
        public List<UserHistoryPlaylists> UserHistoryPlaylists { get; set; }
        public List<UserHistoryArtists> UserHistoryArtists { get; set; }
    }
}
