using FluentValidation;
using GamesLibraryAPI.Entities;
using GamesLibraryShared.User;

namespace GamesLibraryAPI.Validators;

public class RegisterUserValidator : AbstractValidator<UserRegisterRequest>
{
    public RegisterUserValidator(AppDbContext dbContext)
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("{PropertyName} field shouldn't be empty");

        RuleFor(x => x.Surname)
            .NotEmpty()
            .WithMessage("{PropertyName} field shouldn't be empty");

        RuleFor(x => x.Username)
            .NotEmpty()
            .WithMessage("{PropertyName} field shouldn't be empty");

        RuleFor(x => x.DateOfBirth)
            .NotEmpty()
            .WithMessage("{PropertyName} field shouldn't be empty");

        RuleFor(x => x.DateOfBirth)
            .NotEmpty()
            .WithMessage("{PropertyName} field shouldn't be empty");

        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("{PropertyName} field shouldn't be empty")
            .Matches(@"\A(?:[a-zA-Z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z")
            .WithMessage("Wrong email address format");

        RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage("{PropertyName} field shouldn't be empty")
            .MinimumLength(6)
            .WithMessage("Minimum password length is 6 characters")
            .Matches(@"[A-Z]+").WithMessage("Your password must contain at least one uppercase letter.")
            .Matches(@"[a-z]+").WithMessage("Your password must contain at least one lowercase letter.")
            .Matches(@"[0-9]+").WithMessage("Your password must contain at least one number.");

        RuleFor(x => x.ConfirmPassword)
            .NotEmpty()
            .WithMessage("{PropertyName} field shouldn't be empty")
            .Equal(e => e.Password)
            .WithMessage("Passwords do not match");

        RuleFor(x => x.Email)
            .Custom((value, context) =>
            {
                var emailInUse = dbContext.Users.Any(u => u.Email == value);

                if (emailInUse)
                {
                    context.AddFailure("Email", "That email is taken");
                }
            });

        RuleFor(x => x.Username)
            .Custom((value, context) =>
            {
                var emailInUse = dbContext.Users.Any(u => u.UserName == value);

                if (emailInUse)
                {
                    context.AddFailure("UserName", "That username is taken");
                }
            });
    }
}