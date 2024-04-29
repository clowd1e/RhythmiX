﻿using Newtonsoft.Json;
using RhythmiX.Storage.Models.Interfaces;

namespace RhythmiX.Storage.Models
{
    public class TrackModel : IHomeObservable, IHistoryObservable
    {
        [JsonProperty("album_id")]
        public long AlbumId { get; set; }
        [JsonProperty("album_name")]
        public string AlbumName { get; set; }
        public long Id { get; set; }
        [JsonProperty("artist_id")]
        public long ArtistId { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }
        public DateOnly ReleaseDate { get; set; }
        [JsonProperty("album_image")]
        public string AlbumImage { get; set; }
        public string Image { get; set; }
        public string Audio { get; set; }
        public string AudioDownload { get; set; }
        public MusicInfoModel? MusicInfo { get; set; }
    }
}
