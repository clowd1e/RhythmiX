using RhythmiX.Storage.Entities;
using RhythmiX.Storage.Models;
using RhythmiX.Storage.Models.Interfaces;

namespace RhythmiX.Storage.Repository
{
    public interface IMusicRepository
    {
        Task<List<IHomeObservable>> GetUserHomePageContentAsync(long userId);
        Task<List<TrackModel>> GetUserLikedTracksAsync(long userId);
        Task<List<PlaylistModel>> GetUserLikedPlaylistsAsync(long userId);
        Task<List<IHistoryObservable>> GetUserHistoryAsync(long userId);
        Task<TrackModel> GetTrackByIdAsync(long trackId);
        Task<PlaylistModel> GetPlaylistByIdAsync(long playlistId);
        Task<ArtistModel> GetArtistByIdAsync(long artistId);
        Task<AlbumModel> GetAlbumByIdAsync(long albumId);
    }
}
