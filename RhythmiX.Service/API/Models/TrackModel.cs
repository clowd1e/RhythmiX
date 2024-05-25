using Newtonsoft.Json;
using RhythmiX.Service.API.Models.Interfaces;
using RhythmiX.Storage.Entities;

namespace RhythmiX.Service.API.Models
{
    public class TrackModel : IHomeObservable, IHistoryObservable
    {
        [JsonProperty("album_id")]
        public long? AlbumId { get; set; }
        [JsonProperty("album_name")]
        public string AlbumName { get; set; }
        public long Id { get; set; }
        [JsonProperty("artist_id")]
        public long ArtistId { get; set; }
        [JsonProperty("artist_name")]
        public string ArtistName { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }
        public DateOnly ReleaseDate { get; set; }
        [JsonProperty("album_image")]
        public string AlbumImage { get; set; }
        public string Image { get; set; }
        public string Audio { get; set; }
        public string AudioDownload { get; set; }
        [JsonProperty("audiodownload_allowed")]
        public bool AudioDownloadAllowed { get; set; }
        public MusicInfoModel? MusicInfo { get; set; }
    }
}
