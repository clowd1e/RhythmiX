using RhythmiX.Service.API.Models;
using RhythmiX.Service.API.Models.Interfaces;
using RhythmiX.Storage.Entities;

namespace RhythmiX.Service.Queries.Dtos
{
    public class PlaylistDto : IHomeObservable
    {
        public long Id { get; set; }
        public string PlaylistName { get; set; }
        public string UserName { get; set; }
        public string Image { get; set; }

        public PlaylistDto(Playlist playlist)
        {
            Id = playlist.ApiId;
            PlaylistName = playlist.Name;
            UserName = playlist.UserName;
            Image = $"{PlaylistName}.jpg";
        }

        public PlaylistDto(PlaylistModel playlistModel)
        {
            Id = playlistModel.Id;
            PlaylistName = playlistModel.Name;
            UserName = playlistModel.UserName;
            Image = $"{PlaylistName}.jpg";
        }
    }
}
