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

        public async Task<IEnumerable<Track>> GetUserHistoryTracksAsync(long userId)
        {
            return await _context.Tracks.Include(t => t.HistoryUsers).Where(t => t.HistoryUsers.Any(u => u.Id == userId)).ToListAsync();
        }

        public async Task<IEnumerable<Playlist>> GetUserLikedPlaylistsAsync(long userId)
        {
            return await _context.Playlists.Include(p => p.LikedUsers).Where(p => p.LikedUsers.Any(u => u.Id == userId)).ToListAsync();
        }

        public async Task<IEnumerable<Track>> GetUserLikedTracksAsync(long userId)
        {
            return await _context.Tracks.Include(t => t.LikedUsers).Where(t => t.LikedUsers.Any(u => u.Id == userId)).ToListAsync();
        }

        public async Task<bool> IsAlbumLiked(long userId, long albumId)
        {
            return await _context.Albums.Include(a => a.LikedUsers).AnyAsync(a => a.Id == albumId && a.LikedUsers.Any(u => u.Id == userId));
        }

        public async Task<bool> IsArtistLiked(long userId, long artistId)
        {
            return await _context.Artists.Include(a => a.LikedUsers).AnyAsync(a => a.Id == artistId && a.LikedUsers.Any(u => u.Id == userId));
        }

        public async Task<bool> IsPlaylistLiked(long userId, long playlistId)
        {
            return await _context.Playlists.Include(p => p.LikedUsers).AnyAsync(p => p.Id == playlistId && p.LikedUsers.Any(u => u.Id == userId));
        }

        public async Task<bool> IsTrackLiked(long userId, long trackId)
        {
            return await _context.Tracks.Include(t => t.LikedUsers).AnyAsync(t => t.Id == trackId && t.LikedUsers.Any(u => u.Id == userId));
        }

        public async Task RemoveLikedAlbumAsync(long userId, long albumId)
        {
            User user = await _context.Users.FindAsync(userId);
            Album album = await _context.Albums.Include(a => a.LikedUsers).FirstOrDefaultAsync(a => a.Id == albumId);

            if (user is null || album is null)
                return;

            album.LikedUsers.Remove(user);
            if (!album.LikedUsers.Any())
                _context.Albums.Remove(album);

            await _context.SaveChangesAsync();
        }

        public async Task RemoveLikedArtistAsync(long userId, long artistId)
        {
            User user = await _context.Users.FindAsync(userId);
            Artist artist = await _context.Artists.Include(a => a.LikedUsers).FirstOrDefaultAsync(a => a.Id == artistId);

            if (user is null || artist is null)
                return;

            artist.LikedUsers.Remove(user);
            if (!artist.LikedUsers.Any())
                _context.Artists.Remove(artist);

            await _context.SaveChangesAsync();
        }

        public async Task RemoveLikedPlaylistAsync(long userId, long playlistId)
        {
            User user = await _context.Users.FindAsync(userId);
            Playlist playlist = await _context.Playlists.Include(a => a.LikedUsers).FirstOrDefaultAsync(a => a.Id == playlistId);

            if (user is null || playlist is null)
                return;

            playlist.LikedUsers.Remove(user);
            if (!playlist.LikedUsers.Any())
                _context.Playlists.Remove(playlist);

            await _context.SaveChangesAsync();
        }

        public async Task RemoveLikedTrackAsync(long userId, long trackId)
        {
            User user = await _context.Users.FindAsync(userId);
            Track track = await _context.Tracks.Include(a => a.LikedUsers).FirstOrDefaultAsync(a => a.Id == trackId);

            if (user is null || track is null)
                return;

            track.LikedUsers.Remove(user);
            if (!track.LikedUsers.Any())
                _context.Tracks.Remove(track);

            await _context.SaveChangesAsync();
        }
    }
}
