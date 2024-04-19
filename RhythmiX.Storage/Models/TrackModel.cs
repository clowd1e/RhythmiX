using RhythmiX.Storage.Models.Interfaces;

namespace RhythmiX.Storage.Models
{
    public class TrackModel : IHomeObservable, IHistoryObservable
    {
        public string AlbumId { get; set; }
        public string AlbumName { get; set; }
        public long Id { get; set; }
        public string Name { get; set; }
        public string Duration { get; set; }
        public DateOnly ReleaseDate { get; set; }
        public string AlbumImage { get; set; }
        public string Image { get; set; }
        public string Audio { get; set; }
        public string AudioDownload { get; set; }
        public MusicInfoModel MusicInfo { get; set; }
    }
}
