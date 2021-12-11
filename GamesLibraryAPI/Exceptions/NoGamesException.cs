namespace GamesLibraryAPI.Exceptions;

public class NoGamesException : Exception
{
    public NoGamesException(string message) : base(message)
    {
        
    }
}