using Microsoft.EntityFrameworkCore;
using RhythmiX.Storage.Entities;

namespace RhythmiX.Storage.Repository
{
    public class MusicRepository : IMusicRepository
    {
        private readonly MusicDbContext _context;
        public MusicRepository(MusicDbContext context)
        {
            _context = context;
        }

        public async Task AddAlbumToHistory(long userId, Album album)
        {
            throw new NotImplementedException();
        }

        public async Task AddArtistToHistory(long userId, Artist artist)
        {
            throw new NotImplementedException();
        }

        public async Task AddLikedAlbumAsync(long userId, Album album)
        {
            throw new NotImplementedException();
        }

        public async Task AddLikedArtistAsync(long userId, Artist artist)
        {
            throw new NotImplementedException();
        }

        public async Task AddLikedPlaylistAsync(long userId, Playlist playlist)
        {
            throw new NotImplementedException();
        }

        public async Task AddLikedTrackAsync(long userId, Track track)
        {
            throw new NotImplementedException();
        }

        public async Task AddPlaylistToHistory(long userId, Playlist playlist)
        {
            throw new NotImplementedException();
        }

        public async Task AddTrackToHistory(long userId, Track track)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Playlist>> GetUserLikedPlaylistsAsync(long userId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Track>> GetUserLikedTracksAsync(long userId)
        {
            return await _context.Tracks.Include(t => t.LikedUsers).Where(t => t.LikedUsers.Any(u => u.Id == userId)).ToListAsync();
        }

        public async Task<bool> IsAlbumLiked(long userId, long albumId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> IsArtistLiked(long userId, long artistId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> IsPlaylistLiked(long userId, long playlistId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> IsTrackLiked(long userId, long trackId)
        {
            throw new NotImplementedException();
        }

        public async Task RemoveLikedAlbumAsync(long userId, long albumId)
        {
            throw new NotImplementedException();
        }

        public async Task RemoveLikedArtistAsync(long userId, long artistId)
        {
            throw new NotImplementedException();
        }

        public async Task RemoveLikedPlaylistAsync(long userId, long playlistId)
        {
            throw new NotImplementedException();
        }

        public async Task RemoveLikedTrackAsync(long userId, long trackId)
        {
            throw new NotImplementedException();
        }
    }
}
