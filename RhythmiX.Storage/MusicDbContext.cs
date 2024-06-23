using Microsoft.EntityFrameworkCore;
using RhythmiX.Storage.Entities;
using RhythmiX.Storage.Entities.ManyToMany;

namespace RhythmiX.Storage
{
    public class MusicDbContext : DbContext
    {
        public DbSet<Album> Albums { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Playlist> Playlists { get; set; }
        public DbSet<Track> Tracks { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<UserLikedTracks> UserLikedTracks { get; set; }
        public DbSet<UserLikedAlbums> UserLikedAlbums { get; set; }
        public DbSet<UserLikedPlaylists> UserLikedPlaylists { get; set; }
        public DbSet<UserLikedArtists> UserLikedArtists { get; set; }

        public DbSet<UserHistoryTracks> UserHistoryTracks { get; set; }
        public DbSet<UserHistoryAlbums> UserHistoryAlbums { get; set; }
        public DbSet<UserHistoryPlaylists> UserHistoryPlaylists { get; set; }
        public DbSet<UserHistoryArtists> UserHistoryArtists { get; set; }

        public MusicDbContext() : base() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=DESKTOP-HJ1SM1F\SQLEXPRESS;database=music_db;trusted_connection=true;TrustServerCertificate=true;",
                x => x.MigrationsHistoryTable("__EFMigrationsHistory", "MusicDb"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);



            modelBuilder.Entity<UserLikedTracks>()
                .HasKey(ult => ult.Id);
            modelBuilder.Entity<UserLikedTracks>()
                .HasIndex(ult => new { ult.UserId, ult.TrackId })
                .IsUnique();

            modelBuilder.Entity<UserLikedTracks>()
                .HasOne(ult => ult.User)
                .WithMany(u => u.UserLikedTracks)
                .HasForeignKey(ult => ult.UserId);
            modelBuilder.Entity<UserLikedTracks>()
                .HasOne(ult => ult.Track)
                .WithMany(t => t.UserLikedTracks)
                .HasForeignKey(ult => ult.TrackId);


            modelBuilder.Entity<UserLikedAlbums>()
                .HasKey(ula => ula.Id);
            modelBuilder.Entity<UserLikedAlbums>()
                .HasIndex(ula => new { ula.UserId, ula.AlbumId })
                .IsUnique();

            modelBuilder.Entity<UserLikedAlbums>()
                .HasOne(ula => ula.User)
                .WithMany(u => u.UserLikedAlbums)
                .HasForeignKey(ula => ula.UserId);
            modelBuilder.Entity<UserLikedAlbums>()
                .HasOne(ula => ula.Album)
                .WithMany(a => a.UserLikedAlbums)
                .HasForeignKey(ula => ula.AlbumId);


            modelBuilder.Entity<UserLikedPlaylists>()
                .HasKey(ulp => ulp.Id);
            modelBuilder.Entity<UserLikedPlaylists>()
                .HasIndex(ulp => new { ulp.UserId, ulp.PlaylistId })
                .IsUnique();

            modelBuilder.Entity<UserLikedPlaylists>()
                .HasOne(ulp => ulp.User)
                .WithMany(u => u.UserLikedPlaylists)
                .HasForeignKey(ulp => ulp.UserId);
            modelBuilder.Entity<UserLikedPlaylists>()
                .HasOne(ulp => ulp.Playlist)
                .WithMany(p => p.UserLikedPlaylists)
                .HasForeignKey(ulp => ulp.PlaylistId);



            modelBuilder.Entity<UserLikedArtists>()
                .HasKey(ula => ula.Id);
            modelBuilder.Entity<UserLikedArtists>()
                .HasIndex(ula => new { ula.UserId, ula.ArtistId })
                .IsUnique();

            modelBuilder.Entity<UserLikedArtists>()
                .HasOne(ula => ula.User)
                .WithMany(u => u.UserLikedArtists)
                .HasForeignKey(ula => ula.UserId);
            modelBuilder.Entity<UserLikedArtists>()
                .HasOne(ula => ula.Artist)
                .WithMany(a => a.UserLikedArtists)
                .HasForeignKey(ula => ula.ArtistId);



            modelBuilder.Entity<UserHistoryTracks>()
                .HasKey(uht => uht.Id);
            modelBuilder.Entity<UserHistoryTracks>()
                .HasIndex(uht => new { uht.UserId, uht.TrackId })
                .IsUnique();

            modelBuilder.Entity<UserHistoryTracks>()
                .HasOne(uht => uht.User)
                .WithMany(u => u.UserHistoryTracks)
                .HasForeignKey(uht => uht.UserId);
            modelBuilder.Entity<UserHistoryTracks>()
                .HasOne(uht => uht.Track)
                .WithMany(t => t.UserHistoryTracks)
                .HasForeignKey(uht => uht.TrackId);


            modelBuilder.Entity<UserHistoryAlbums>()
                .HasKey(uha => uha.Id);
            modelBuilder.Entity<UserHistoryAlbums>()
                .HasIndex(uha => new { uha.UserId, uha.AlbumId })
                .IsUnique();

            modelBuilder.Entity<UserHistoryAlbums>()
                .HasOne(uha => uha.User)
                .WithMany(u => u.UserHistoryAlbums)
                .HasForeignKey(uha => uha.UserId);
            modelBuilder.Entity<UserHistoryAlbums>()
                .HasOne(uha => uha.Album)
                .WithMany(a => a.UserHistoryAlbums)
                .HasForeignKey(uha => uha.AlbumId);



            modelBuilder.Entity<UserHistoryPlaylists>()
                .HasKey(uhp => uhp.Id);
            modelBuilder.Entity<UserHistoryPlaylists>()
                .HasIndex(uhp => new { uhp.UserId, uhp.PlaylistId })
                .IsUnique();

            modelBuilder.Entity<UserHistoryPlaylists>()
                .HasOne(uhp => uhp.User)
                .WithMany(u => u.UserHistoryPlaylists)
                .HasForeignKey(uhp => uhp.UserId);
            modelBuilder.Entity<UserHistoryPlaylists>()
                .HasOne(uhp => uhp.Playlist)
                .WithMany(p => p.UserHistoryPlaylists)
                .HasForeignKey(uhp => uhp.PlaylistId);


            modelBuilder.Entity<UserHistoryArtists>()
                .HasKey(uha => uha.Id);
            modelBuilder.Entity<UserHistoryArtists>()
                .HasIndex(uha => new { uha.UserId, uha.ArtistId })
                .IsUnique();

            modelBuilder.Entity<UserHistoryArtists>()
                .HasOne(uha => uha.User)
                .WithMany(u => u.UserHistoryArtists)
                .HasForeignKey(uha => uha.UserId);
            modelBuilder.Entity<UserHistoryArtists>()
                .HasOne(uha => uha.Artist)
                .WithMany(a => a.UserHistoryArtists)
                .HasForeignKey(uha => uha.ArtistId);
        }
    }
}
