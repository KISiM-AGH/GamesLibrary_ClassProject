using System.ComponentModel.DataAnnotations.Schema;
using GamesLibraryShared.Games;

namespace GamesLibraryAPI.Entities;

public class Game : ICloneable
{
    public int GameId { get; set; }
    public string Title { get; set; } = default!;
    public string Description {  get; set; } = default!;
    public decimal Price { get; set; } = default!;
    public DateTime Premiere { get; set; } = default!;

    public int PegiId { get; set; }
    public virtual Pegi Pegi { get; set; } = default!;

    public virtual ICollection<Genre> Genres { get; set; } = default!;

    public virtual ICollection<User>? Users { get; set; }
    
    public virtual ICollection<Platform> Platforms { get; set; } = default!;

    public int CompanyId { get; set; }
    public virtual Company Company { get; set; } = default!;

    public string? PhotoUrl { get; set; } = default!;

    [NotMapped]
    public AvailablePlatforms UserPlatformType { get; set; }

    public object Clone()
    {
        return new Game()
        {
            GameId = GameId,
            Description = Description,
            PegiId = PegiId,
            Pegi = Pegi,
            Users = Users,
            CompanyId = CompanyId,
            Title = this.Title,
            Genres = this.Genres,
            Platforms = this.Platforms,
            Premiere = this.Premiere,
            Price = this.Price,
            Company = this.Company,
            PhotoUrl = this.PhotoUrl,
            UserPlatformType = this.UserPlatformType
        };
    }
}