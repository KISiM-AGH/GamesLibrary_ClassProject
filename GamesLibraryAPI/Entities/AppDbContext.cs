using Microsoft.EntityFrameworkCore;

namespace GamesLibraryAPI.Entities;

public class AppDbContext : DbContext
{
    private readonly IConfiguration _configuration;

    public AppDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public DbSet<Company> Companies { get; set; } = default!;
    public DbSet<Game> Games { get; set; } = default!;
    public DbSet<Genre> Genres { get; set; } = default!;
    public DbSet<Pegi> Pegies { get; set; } = default!;
    public DbSet<Role> Roles { get; set; } = default!;
    public DbSet<User> Users { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Company>()
            .Property(c => c.CompanyName)
            .IsRequired()
            .HasMaxLength(64);

        modelBuilder.Entity<Genre>()
            .Property(g => g.GenreName)
            .IsRequired()
            .HasMaxLength(64);

        modelBuilder.Entity<Pegi>()
            .Property(p => p.PegiValue)
            .IsRequired()
            .HasMaxLength(64);

        modelBuilder.Entity<Role>()
            .Property(p => p.RoleName)
            .IsRequired()
            .HasMaxLength(64);

        modelBuilder.Entity<User>()
            .Property(u => u.UserName)
            .IsRequired();

        modelBuilder.Entity<User>()
           .Property(u => u.DateOfBirth)
           .IsRequired();

        modelBuilder.Entity<User>()
           .Property(u => u.RoleId)
           .IsRequired();

        modelBuilder.Entity<User>()
           .Property(u => u.Email)
           .IsRequired();

        modelBuilder.Entity<User>()
           .Property(u => u.Surname)
           .IsRequired();

        modelBuilder.Entity<User>()
           .Property(u => u.Name)
           .IsRequired();
        
        modelBuilder.Entity<User>()
            .Property(u => u.UserId)
            .IsRequired();

        modelBuilder.Entity<User>()
           .Property(u => u.HashedPassword)
           .IsRequired();

        modelBuilder.Entity<Game>()
            .Property(g => g.Title)
            .IsRequired();

        modelBuilder.Entity<Game>()
            .Property(g => g.CompanyId)
            .IsRequired();

        modelBuilder.Entity<Game>()
            .Property(g => g.PegiId)
            .IsRequired();

        modelBuilder.Entity<Game>()
            .Property(g => g.Price)
            .IsRequired();
        
        modelBuilder.Entity<Game>()
            .Property(g => g.GameId)
            .IsRequired();
        
        modelBuilder.Entity<Genre>()
            .Property(g => g.GenreId)
            .IsRequired();
        
        modelBuilder.Entity<Company>()
            .Property(c => c.CompanyId)
            .IsRequired();

        modelBuilder.Entity<Pegi>()
            .Property(p => p.PegiId)
            .IsRequired();

        modelBuilder.Entity<Role>()
            .Property(p => p.RoleId)
            .IsRequired();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_configuration["Database:SqlServer"]);
    }
}