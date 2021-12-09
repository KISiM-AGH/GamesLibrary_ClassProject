namespace GamesLibraryShared.User;

public class UserResponse
{
    public int UserId { get; set; }
    public string Name {  get; set; } = default!;
    public string Surname { get; set; } = default!;
    public string UserName { get; set; } = default!;
    public string Email {  get; set; } = default!;
    public DateTime DateOfBirth { get; set; }

    public string Role { get; set; } = default!;
}