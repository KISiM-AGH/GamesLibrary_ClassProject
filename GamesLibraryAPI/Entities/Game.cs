namespace GamesLibraryAPI.Entities;

public class Game
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

    public int CompanyId { get; set; }
    public virtual Company Company { get; set; } = default!;
}