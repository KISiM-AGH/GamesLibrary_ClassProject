namespace GamesLibraryAPI.Entities;

public class Company
{
    public int CompanyId { get; set; }
    public string CompanyName { get; set; } = default!;
    public virtual ICollection<Game> Games { get; set; } = default!;
}