using RhythmiX.Storage.Models;

namespace RhythmiX.Service.Queries.Dtos
{
    public class TrackDto
    {
        public long Id { get; set; }
        public string TrackName { get; set; }
        public string ArtistName { get; set; }
        public string Image { get; set; }

        public TrackDto(TrackModel trackModel)
        {
            Id = trackModel.Id;
            TrackName = trackModel.Name;
            ArtistName = trackModel.ArtistName;
            Image = $"{TrackName}.jpg";
        }
    }
}
