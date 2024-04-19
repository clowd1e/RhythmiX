using RhythmiX.Storage.Models.Interfaces;

namespace RhythmiX.Storage.Models
{
    public class PlaylistModel : IHomeObservable, IHistoryObservable
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateOnly CreationDate { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Zip { get; set; }
    }
}
