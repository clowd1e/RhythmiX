using Newtonsoft.Json;
using RhythmiX.Storage.Common;
using RhythmiX.Storage.Entities.ManyToMany;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RhythmiX.Storage.Entities
{
    [Table("Playlists", Schema = "MusicDb")]
    public class Playlist : BaseEntity
    {
        [Required]
        public long ApiId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateOnly CreationDate { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Zip { get; set; }

        public List<UserLikedPlaylists> UserLikedPlaylists { get; set; }
        public List<UserHistoryPlaylists> UserHistoryPlaylists { get; set; }

        protected Playlist() { }
        public Playlist(long apiId, string name, DateOnly creationDate, string userId, string userName, string zip)
        {
            ApiId = apiId;
            Name = name;
            CreationDate = creationDate;
            UserId = userId;
            UserName = userName;
            Zip = zip;
        }
    }
}
