using RhythmiX.Service.API.Models;
using RhythmiX.Service.API.Models.Interfaces;
using RhythmiX.Storage.Entities;

namespace RhythmiX.Service.Queries.Dtos
{
    public class TrackDto : IHomeObservable
    {
        private const int SECONDS_IN_MINUTE = 60;
        public long Id { get; set; }
        public string TrackName { get; set; }
        public string ArtistName { get; set; }
        public string Image { get; set; }
        public string Duration { get; set; }

        public TrackDto(Track track)
        {
            Id = track.ApiId;
            TrackName = track.Name;
            ArtistName = track.ArtistName;
            Image = $"{TrackName}.jpg";
            string minutes = (track.Duration / SECONDS_IN_MINUTE).ToString();
            string seconds = (track.Duration % SECONDS_IN_MINUTE).ToString();
            Duration = $"{minutes}:{(seconds.Length == 1 ? "0" + seconds : seconds)}";
        }

        public TrackDto(TrackModel trackModel)
        {
            Id = trackModel.Id;
            TrackName = trackModel.Name;
            ArtistName = trackModel.ArtistName;
            Image = $"{TrackName}.jpg";
            string minutes = (trackModel.Duration / SECONDS_IN_MINUTE).ToString();
            string seconds = (trackModel.Duration % SECONDS_IN_MINUTE).ToString();
            Duration = $"{minutes}:{(seconds.Length == 1 ? "0" + seconds : seconds)}";
        }

        public TrackDto() { }
    }
}
