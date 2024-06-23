using RhythmiX.Storage.Common;

namespace RhythmiX.Storage.Entities.ManyToMany
{
    public class UserLikedPlaylists : BaseEntity
    {
        public long UserId { get; set; }
        public long PlaylistId { get; set; }
        public User User { get; set; }
        public Playlist Playlist { get; set; }
    }
}
