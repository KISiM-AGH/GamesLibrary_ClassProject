namespace GamesLibraryShared.User;

public class AuthenticateResponse : BaseResponse
{
    public string JwtToken { get; set; } = default!;
}