using Microsoft.EntityFrameworkCore;
using RhythmiX.Storage.Entities;
using RhythmiX.Storage.Entities.ManyToMany;

namespace RhythmiX.Storage.Repository
{
    public class MusicRepository : IMusicRepository
    {
        private readonly MusicDbContext _context;
        public MusicRepository(MusicDbContext context)
        {
            _context = context;
        }

        public async Task AddAlbumToHistoryAsync(long userId, Album album)
        {
            throw new NotImplementedException();
        }

        public async Task AddArtistToHistoryAsync(long userId, Artist artist)
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

        public async Task AddPlaylistToHistoryAsync(long userId, Playlist playlist)
        {
            throw new NotImplementedException();
        }

        public async Task AddTrackToHistoryAsync(long userId, Track track)
        {
            var dbTrack = await _context.Tracks.FindAsync(track.Id);
            var user = await _context.Users.FindAsync(userId);
            if (user is null)
                return;

            if (dbTrack is not null)
            {
                var dbRelation = _context.UserHistoryTracks.FirstOrDefault(uht => uht.UserId == userId && uht.TrackId == dbTrack.Id);
                if (dbRelation is not null)
                {
                    _context.UserHistoryTracks.Remove(dbRelation);
                    await _context.SaveChangesAsync();

                    dbRelation = new UserHistoryTracks { UserId = userId, TrackId = dbTrack.Id };
                    _context.UserHistoryTracks.Add(dbRelation);
                    await _context.SaveChangesAsync();
                    return;
                }

                dbRelation = new UserHistoryTracks { UserId = userId, TrackId = dbTrack.Id };
                _context.UserHistoryTracks.Add(dbRelation);
                await _context.SaveChangesAsync();
                return;
            }

            _context.Tracks.Add(track);
            await _context.SaveChangesAsync();

            var relation = new UserHistoryTracks() { UserId = userId, TrackId = track.Id };
            _context.UserHistoryTracks.Add(relation);

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Track>> GetUserHistoryTracksAsync(long userId)
        {
            return await _context.UserHistoryTracks.Include(uht => uht.Track).Where(uht => uht.UserId == userId).OrderByDescending(uht => uht.Id).Select(uht => uht.Track).ToListAsync();
        }

        public async Task<IEnumerable<Playlist>> GetUserLikedPlaylistsAsync(long userId)
        {
            return await _context.UserLikedPlaylists.Include(ulp => ulp.Playlist).Where(ulp => ulp.UserId == userId).Select(uht => uht.Playlist).ToListAsync();
        }

        public async Task<IEnumerable<Track>> GetUserLikedTracksAsync(long userId)
        {
            return await _context.UserLikedTracks.Include(ult => ult.Track).Where(ult => ult.UserId == userId).Select(ult => ult.Track).ToListAsync();
        }

        public async Task<bool> IsAlbumLiked(long userId, long albumId)
        {
            return await _context.UserLikedAlbums.FindAsync(userId, albumId) is not null;
        }

        public async Task<bool> IsArtistLiked(long userId, long artistId)
        {
            return await _context.UserLikedArtists.FindAsync(userId, artistId) is not null;
        }

        public async Task<bool> IsPlaylistLiked(long userId, long playlistId)
        {
            return await _context.UserLikedPlaylists.FindAsync(userId, playlistId) is not null;
        }

        public async Task<bool> IsTrackLastInHistory(long userId, long trackId)
        {
            return await _context.UserHistoryTracks.FindAsync(userId, trackId) is not null;
        }

        public async Task<bool> IsTrackLiked(long userId, long trackId)
        {
            return await _context.UserLikedTracks.FindAsync(userId, trackId) is not null;
        }

        public async Task RemoveLikedAlbumAsync(long userId, long albumId)
        {
            User user = await _context.Users.FindAsync(userId);
            Album album = _context.UserLikedAlbums.Include(ula => ula.Album).FirstOrDefault(ula => ula.UserId == userId && ula.AlbumId == albumId).Album;

            if (user is null || album is null)
                return;

            _context.UserLikedAlbums.Remove(new UserLikedAlbums { UserId = userId, AlbumId = albumId });
            if (!_context.UserLikedAlbums.Any(ula => ula.AlbumId == albumId))
                _context.Albums.Remove(album);

            await _context.SaveChangesAsync();
        }

        public async Task RemoveLikedArtistAsync(long userId, long artistId)
        {
            User user = await _context.Users.FindAsync(userId);
            Artist artist = _context.UserLikedArtists.Include(ula => ula.Artist).FirstOrDefault(ula => ula.UserId == userId && ula.ArtistId == artistId).Artist;

            if (user is null || artist is null)
                return;

            _context.UserLikedArtists.Remove(new UserLikedArtists { UserId = userId, ArtistId = artistId });
            if (!_context.UserLikedArtists.Any(ula => ula.ArtistId == artistId))
                _context.Artists.Remove(artist);

            await _context.SaveChangesAsync();
        }

        public async Task RemoveLikedPlaylistAsync(long userId, long playlistId)
        {
            User user = await _context.Users.FindAsync(userId);
            Playlist playlist = _context.UserLikedPlaylists.Include(ulp => ulp.Playlist).FirstOrDefault(ulp => ulp.UserId == userId && ulp.PlaylistId == playlistId).Playlist;

            if (user is null || playlist is null)
                return;

            _context.UserLikedPlaylists.Remove(new UserLikedPlaylists { UserId = userId, PlaylistId = playlistId });
            if (!_context.UserLikedPlaylists.Any(ulp => ulp.PlaylistId == playlistId))
                _context.Playlists.Remove(playlist);

            await _context.SaveChangesAsync();
        }

        public async Task RemoveLikedTrackAsync(long userId, long trackId)
        {
            User user = await _context.Users.FindAsync(userId);
            Track track = _context.UserLikedTracks.Include(ult => ult.Track).FirstOrDefault(ult => ult.UserId == userId && ult.TrackId == trackId).Track;

            if (user is null || track is null)
                return;

            _context.UserLikedTracks.Remove(new UserLikedTracks { UserId = userId, TrackId = trackId });
            if (!_context.UserLikedTracks.Any(ulp => ulp.TrackId == trackId))
                _context.Tracks.Remove(track);

            await _context.SaveChangesAsync();
        }
    }
}
