using FluentValidation;
using GamesLibraryShared.User;

namespace GamesLibraryAPI.Validators;

public class LoginUserValidator : AbstractValidator<UserLoginRequest>
{
    public LoginUserValidator()
    {
        RuleFor(x => x.Username)
            .NotEmpty()
            .WithMessage("{PropertyName} field shouldn't be empty");

        RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage("{PropertyName} field shouldn't be empty");
    }
}