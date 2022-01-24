using FluentValidation;
using GamesLibraryShared.Games;
using GamesLibraryShared.User;

namespace GamesLibraryAPI.Validators;

public class AddGameToUserValidator : AbstractValidator<GameUserRequest>
{
    public AddGameToUserValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("{PropertyName} field shouldn't be empty");
        RuleFor(x => x.Platform)
            .NotEmpty()
            .WithMessage("{PropertyName} field shouldn't be empty");
        RuleFor(x => x.Title)
            .NotEmpty()
            .WithMessage("{PropertyName} field shouldn't be empty");
    }
}