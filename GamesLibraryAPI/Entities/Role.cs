using GamesLibraryShared.User;

namespace GamesLibraryAPI.Entities;

public class Role
{
    public int RoleId { get; set; }
    public AvailableRoles RoleName {  get; set; } = default!;
    public virtual ICollection<User> Users { get; set; } = default!;
}