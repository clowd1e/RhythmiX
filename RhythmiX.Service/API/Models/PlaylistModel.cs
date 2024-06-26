﻿using Newtonsoft.Json;
using RhythmiX.Service.API.Models.Interfaces;

namespace RhythmiX.Service.API.Models
{
    public class PlaylistModel : IHomeObservable, IHistoryObservable
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateOnly CreationDate { get; set; }
        [JsonProperty("user_id")]
        public string UserId { get; set; }
        [JsonProperty("user_name")]
        public string UserName { get; set; }
        public string Zip { get; set; }
    }
}
