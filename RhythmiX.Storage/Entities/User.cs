using RhythmiX.Storage.Common;
using RhythmiX.Storage.Models.Interfaces;
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
        [MaxLength(30)]
        public string Password { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        

        public List<Track> LikedTracks { get; set; } = new List<Track>();
        public List<Album> LikedAlbums { get; set; } = new List<Album>();
        public List<Playlist> LikedPlaylists { get; set; } = new List<Playlist>();
        public List<Artist> LikedArtists { get; set; } = new List<Artist>();
        public List<Track> HistoryTracks { get; set; } = new List<Track>();
        public List<Album> HistoryAlbums { get; set; } = new List<Album>();
        public List<Playlist> HistoryPlaylists { get; set; } = new List<Playlist>();
        public List<Artist> HistoryArtists { get; set; } = new List<Artist>(); 
    }
}
