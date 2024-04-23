using Newtonsoft.Json;
using RhythmiX.Storage.Models.Interfaces;

namespace RhythmiX.Storage.Models
{
    public class AlbumModel : IHomeObservable, IHistoryObservable
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateOnly ReleaseDate { get; set; }
        [JsonProperty("artist_id")]
        public long ArtistId { get; set; }
        [JsonProperty("artist_name")]
        public string ArtistName { get; set; }
        public string Image { get; set; }
        public string Zip { get; set; }
    }
}
