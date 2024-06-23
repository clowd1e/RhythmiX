using RhythmiX.Storage.Common;

namespace RhythmiX.Storage.Entities.ManyToMany
{
    public class UserHistoryAlbums : BaseEntity
    {
        public long UserId { get; set; }
        public long AlbumId { get; set; }
        public User User { get; set; }
        public Album Album { get; set; }
    }
}
