using Microsoft.EntityFrameworkCore;
using ProjetVeloBackEnd.Entities;

namespace ProjetVeloBackEnd.DAL;
public class AppDbContext : DbContext
{
    /// <summary>
    /// Call the base constructor.
    /// </summary>
    /// <param name="options"></param>
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    /// <summary>
    /// DbSet for User.
    /// </summary>
    public virtual DbSet<User> User { get; set; }

    /// <summary>
    /// DbSet for Favorite.
    /// </summary>
    public virtual DbSet<Favorite> Favorite { get; set; }


    /// <summary>
    /// DbSet for Incident.
    /// </summary>
    public virtual DbSet<Incident> Incident { get; set; }

    /// <summary>
    /// DbSet for Incident type.
    /// </summary>
    public virtual DbSet<IncidentType> IncidentType { get; set; }

    /// <summary>
    /// DbSet for Place.
    /// </summary>
    public virtual DbSet<Place> Place { get; set; }

    /// <summary>
    /// OnModelCreating builder.
    /// </summary>
    /// <param name="modelBuilder"></param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        UserTableInstantiate(modelBuilder);
        FavoriteTableInstantiate(modelBuilder);
        IncidentTableInstantiate(modelBuilder);
        IncidentTypeTableInstantiate(modelBuilder);
        LocationTableInstantiate(modelBuilder);
        PlaceTableInstantiate(modelBuilder);

    }

    /// <summary>
    /// User table instantiation.
    /// </summary>
    /// <param name="modelBuilder"></param>
    private void UserTableInstantiate(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(150);

            entity.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(150);

            entity.Property(e => e.Password)
                .IsRequired()
                .HasMaxLength(50);

            entity.Property(e => e.Pseudo)
            .IsRequired();

            entity.Property(e => e.IsAdmin)
            .IsRequired();
        });
    }

    /// <summary>
    /// Favorite table instantiation.
    /// </summary>
    /// <param name="modelBuilder"></param>
    private void FavoriteTableInstantiate(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Favorite>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(250);
        });
    }

    /// <summary>
    /// Incident table instantiation.
    /// </summary>
    /// <param name="modelBuilder"></param>
    private void IncidentTableInstantiate(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Incident>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.CountFinished)
                .IsRequired()
                .HasMaxLength(20);

            entity.HasOne(e => e.Location)
            .WithMany(e => e.Incidents);
        });
    }

    /// <summary>
    /// Incident Type table instantiation.
    /// </summary>
    /// <param name="modelBuilder"></param>
    private void IncidentTypeTableInstantiate(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<IncidentType>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);
        });
    }

    /// <summary>
    /// Location table instantiation.
    /// </summary>
    /// <param name="modelBuilder"></param>
    private void LocationTableInstantiate(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Location>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Latitude)
                .IsRequired();

            entity.Property(e => e.Longitude)
                .IsRequired();

            entity.Property(e => e.Altitude)
                .IsRequired();
        });
    }

    /// <summary>
    /// Place table instantiation.
    /// </summary>
    /// <param name="modelBuilder"></param>
    private void PlaceTableInstantiate(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Place>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.City)
                .IsRequired()
                .HasMaxLength(250);

            entity.Property(e => e.PostalCode)
                .IsRequired()
                .HasMaxLength(250);

            entity.Property(e => e.Adress)
                .IsRequired()
                .HasMaxLength(250);

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(250);

        });
    }
}
