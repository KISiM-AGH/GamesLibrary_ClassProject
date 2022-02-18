using FluentValidation;
using GamesLibraryShared.Games;

namespace GamesLibraryAPI.Validators;

public class AddGameAdminValidator : AbstractValidator<GameAdminRequest>
{
    public AddGameAdminValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .WithMessage("{PropertyName} field shouldn't be empty");

        RuleFor(x => x.PegiId)
            .NotEmpty()
            .WithMessage("{PropertyName} field shouldn't be empty");
        
        RuleFor(x => x.Genres)
            .NotEmpty()
            .WithMessage("{PropertyName} field shouldn't be empty");
        
        RuleFor(x => x.Premiere)
            .NotEmpty()
            .WithMessage("{PropertyName} field shouldn't be empty");
        
        RuleFor(x => x.Price)
            .NotEmpty()
            .WithMessage("{PropertyName} field shouldn't be empty");
        
        RuleFor(x => x.CompanyId)
            .NotEmpty()
            .WithMessage("{PropertyName} field shouldn't be empty");
        
        RuleFor(x => x.PlatformsList)
            .NotEmpty()
            .WithMessage("{PropertyName} field shouldn't be empty");
    }
}