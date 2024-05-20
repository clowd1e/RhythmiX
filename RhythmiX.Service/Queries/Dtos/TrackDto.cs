using RhythmiX.Storage.Models;

namespace RhythmiX.Service.Queries.Dtos
{
    public class TrackDto
    {
        private const int SECONDS_IN_MINUTE = 60;
        public long Id { get; set; }
        public string TrackName { get; set; }
        public string ArtistName { get; set; }
        public string Image { get; set; }
        public string Duration { get; set; }

        public TrackDto(TrackModel trackModel)
        {
            Id = trackModel.Id;
            TrackName = trackModel.Name;
            ArtistName = trackModel.ArtistName;
            Image = $"{TrackName}.jpg";
            Duration = $"{trackModel.Duration / SECONDS_IN_MINUTE}:{trackModel.Duration % SECONDS_IN_MINUTE}";
        }

        public TrackDto() { }
    }
}
