using RhythmiX.Storage.Common;

namespace RhythmiX.Storage.Entities.ManyToMany
{
    public class UserLikedTracks : BaseEntity
    {
        public long UserId { get; set; }
        public long TrackId { get; set; }
        public User User { get; set; }
        public Track Track { get; set; }
    }
}
