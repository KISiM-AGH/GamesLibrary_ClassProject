namespace GamesLibraryAPI.Entities;

public class User
{
    public int UserId { get; set; }
    public string Name {  get; set; } = default!;
    public string Surname { get; set; } = default!;
    public string UserName { get; set; } = default!;
    public string Email {  get; set; } = default!;
    public string HashedPassword { get; set; } = default!;
    public string? Description { get; set; } = default!;
    public DateTime DateOfBirth { get; set; } = default!;

    public int RoleId { get; set; }
    public Role Role { get; set; } = default!;

    public virtual ICollection<Game>? Games { get; set; }
}