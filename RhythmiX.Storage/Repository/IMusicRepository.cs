using RhythmiX.Storage.Entities;

namespace RhythmiX.Storage.Repository
{
    public interface IMusicRepository
    {
        Task<IEnumerable<Track>> GetUserLikedTracksAsync(long userId);
        Task<IEnumerable<Playlist>> GetUserLikedPlaylistsAsync(long userId);

        Task<IEnumerable<Track>> GetUserHistoryTracksAsync(long userId);

        Task AddLikedTrackAsync(long userId, Track track);
        Task RemoveLikedTrackAsync(long userId, long trackId);

        Task AddLikedPlaylistAsync(long userId, Playlist playlist);
        Task RemoveLikedPlaylistAsync(long userId, long playlistId);

        Task AddLikedAlbumAsync(long userId, Album album);
        Task RemoveLikedAlbumAsync(long userId, long albumId);

        Task AddLikedArtistAsync(long userId, Artist artist);
        Task RemoveLikedArtistAsync(long userId, long artistId);



        Task AddArtistToHistoryAsync(long userId, Artist artist);
        Task AddTrackToHistoryAsync(long userId, Track track);
        Task AddPlaylistToHistoryAsync(long userId, Playlist playlist);
        Task AddAlbumToHistoryAsync(long userId, Album album);


        Task<bool> IsTrackLiked(long userId, long trackId);
        Task<bool> IsPlaylistLiked(long userId, long playlistId);
        Task<bool> IsAlbumLiked(long userId, long albumId);
        Task<bool> IsArtistLiked(long userId, long artistId);

        Task<bool> IsTrackLastInHistory(long userId, long trackId);
    }
}
