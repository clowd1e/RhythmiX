using RhythmiX.Service.API.Models;
using RhythmiX.Service.API.Models.Interfaces;
using RhythmiX.Storage.Entities;

namespace RhythmiX.Service.Queries.Dtos
{
    public class AlbumDto : IHomeObservable
    {
        public long Id { get; set; }
        public string AlbumName { get; set; }
        public string ArtistName { get; set; }
        public string Image { get; set; }

        public AlbumDto(Album album)
        {
            Id = album.ApiId;
            AlbumName = album.Name;
            ArtistName = album.ArtistName;
            Image = $"{AlbumName}.jpg";
        }

        public AlbumDto(AlbumModel albumModel)
        {
            Id = albumModel.Id;
            AlbumName = albumModel.Name;
            ArtistName = albumModel.ArtistName;
            Image = $"{AlbumName}.jpg";
        }
    }
}
