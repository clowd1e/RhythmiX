using Microsoft.EntityFrameworkCore;
using RhythmiX.Storage.Entities;

namespace RhythmiX.Storage
{
    public class MusicDbContext : DbContext
    {
        public DbSet<Album> Albums { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Playlist> Playlists { get; set; }
        public DbSet<Track> Tracks { get; set; }
        public DbSet<User> Users { get; set; }

        public MusicDbContext() : base() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=DESKTOP-HJ1SM1F\SQLEXPRESS;database=music_db;trusted_connection=true;TrustServerCertificate=true;",
                x => x.MigrationsHistoryTable("__EFMigrationsHistory", "MusicDb"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Track>()
                .HasMany(t => t.LikedUsers)
                .WithMany(u => u.LikedTracks)
                .UsingEntity(j => j.ToTable("UserLikedTracks", "MusicDb"));

            modelBuilder.Entity<Track>()
                .HasMany(t => t.HistoryUsers)
                .WithMany(u => u.HistoryTracks)
                .UsingEntity(j => j.ToTable("UserHistoryTracks", "MusicDb"));

            modelBuilder.Entity<Album>()
                .HasMany(t => t.LikedUsers)
                .WithMany(u => u.LikedAlbums)
                .UsingEntity(j => j.ToTable("UserLikedAlbums", "MusicDb"));

            modelBuilder.Entity<Album>()
                .HasMany(t => t.HistoryUsers)
                .WithMany(u => u.HistoryAlbums)
                .UsingEntity(j => j.ToTable("UserHistoryAlbums", "MusicDb"));

            modelBuilder.Entity<Playlist>()
                .HasMany(t => t.LikedUsers)
                .WithMany(u => u.LikedPlaylists)
                .UsingEntity(j => j.ToTable("UserLikedPlaylists", "MusicDb"));

            modelBuilder.Entity<Playlist>()
                .HasMany(t => t.HistoryUsers)
                .WithMany(u => u.HistoryPlaylists)
                .UsingEntity(j => j.ToTable("UserHistoryPlaylists", "MusicDb"));

            modelBuilder.Entity<Artist>()
                .HasMany(t => t.LikedUsers)
                .WithMany(u => u.LikedArtists)
                .UsingEntity(j => j.ToTable("UserLikedArtists", "MusicDb"));

            modelBuilder.Entity<Artist>()
                .HasMany(t => t.HistoryUsers)
                .WithMany(u => u.HistoryArtists)
                .UsingEntity(j => j.ToTable("UserHistoryArtists", "MusicDb"));
        }
    }
}
