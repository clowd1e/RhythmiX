using RhythmiX.Storage.Common;

namespace RhythmiX.Storage.Entities.ManyToMany
{
    public class UserHistoryArtists : BaseEntity
    {
        public long UserId { get; set; }
        public long ArtistId { get; set; }
        public User User { get; set; }
        public Artist Artist { get; set; }
    }
}
