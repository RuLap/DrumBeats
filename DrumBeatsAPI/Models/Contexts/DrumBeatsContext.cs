using Microsoft.EntityFrameworkCore;

namespace DrumBeatsAPI.Models.Contexts;

public class DrumBeatsContext : DbContext
{
    public DrumBeatsContext(DbContextOptions<DrumBeatsContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<Exercise> Exercises { get; set; }
    
    public DbSet<Song> Songs { get; set; }

    public DbSet<Artist> Artists { get; set; }

    public DbSet<Album> Albums { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Song>()
            .HasOne(s => s.Album)
            .WithMany(a => a.Songs)
            .HasForeignKey("AlbumId")
            .OnDelete(DeleteBehavior.Restrict);
        
        modelBuilder.Entity<Song>()
            .HasOne(s => s.Artist)
            .WithMany(a => a.Songs)
            .HasForeignKey("ArtistId")
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Album>()
            .HasOne(al => al.Artist)
            .WithMany(ar => ar.Albums)
            .HasForeignKey("ArtistId")
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Album>()
            .HasMany(al => al.Songs)
            .WithOne(s => s.Album)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Artist>()
            .HasMany(ar => ar.Albums)
            .WithOne(al => al.Artist)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Artist>()
            .HasMany(ar => ar.Songs)
            .WithOne(s => s.Artist)
            .OnDelete(DeleteBehavior.Restrict);
    }
}