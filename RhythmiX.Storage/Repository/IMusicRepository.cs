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

        Task AddLikedTrackAsync(long userId, Track track);
        Task RemoveLikedTrackAsync(long userId, long trackId);

        Task AddLikedPlaylistAsync(long userId, Playlist playlist);
        Task RemoveLikedPlaylistAsync(long userId, long playlistId);

        Task AddLikedAlbumAsync(long userId, Album album);
        Task RemoveLikedAlbumAsync(long userId, long albumId);

        Task AddLikedArtistAsync(long userId, Artist artist);
        Task RemoveLikedArtistAsync(long userId, long artistId);



        Task AddArtistToHistory(long userId, Artist artist);
        Task AddTrackToHistory(long userId, Track track);
        Task AddPlaylistToHistory(long userId, Playlist playlist);
        Task AddAlbumToHistory(long userId, Album album);


        Task<bool> IsTrackLiked(long userId, long trackId);
        Task<bool> IsPlaylistLiked(long userId, long playlistId);
        Task<bool> IsAlbumLiked(long userId, long albumId);
        Task<bool> IsArtistLiked(long userId, long artistId);
    }
}
