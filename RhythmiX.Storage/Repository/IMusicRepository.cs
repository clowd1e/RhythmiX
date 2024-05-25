using RhythmiX.Storage.Entities;

namespace RhythmiX.Storage.Repository
{
    public interface IMusicRepository
    {
        Task<IEnumerable<Track>> GetUserLikedTracksAsync(long userId);
        Task<IEnumerable<Playlist>> GetUserLikedPlaylistsAsync(long userId);

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
