using RhythmiX.Service.API.Models;
using RhythmiX.Service.API.Models.Interfaces;
using RhythmiX.Storage.Entities;

namespace RhythmiX.Service.Queries.Dtos
{
    public class ArtistDto : IHomeObservable
    {
        public long Id { get; set; }
        public string ArtistName { get; set; }
        public string Image { get; set; }

        public ArtistDto(Artist artist)
        {
            Id = artist.ApiId;
            ArtistName = artist.Name;
            Image = $"{ArtistName}.jpg";
        }

        public ArtistDto(ArtistModel artistModel)
        {
            Id = artistModel.Id;
            ArtistName = artistModel.Name;
            Image = $"{ArtistName}.jpg";
        }
    }
}
