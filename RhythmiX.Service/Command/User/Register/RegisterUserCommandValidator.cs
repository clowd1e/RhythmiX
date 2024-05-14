using FluentValidation;

namespace RhythmiX.Service.Command.User.Register
{
    public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserCommandValidator()
        {
            RuleFor(x => x.Username).NotEmpty();
            RuleFor(x => x.Password).NotEmpty();
            RuleFor(x => x.Email).NotEmpty();
            RuleFor(x => x.RepeatPassword).NotEmpty();
            RuleFor(x => x.Username).MinimumLength(3);
            RuleFor(x => x.Username).MaximumLength(50);
            RuleFor(x => x.Password).MinimumLength(8);
            RuleFor(x => x.Password).MaximumLength(30);
            RuleFor(x => x.Password).Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,30}$")
                .WithMessage("Password must contain at least one uppercase letter, one lowercase letter and one digit");
            RuleFor(x => x.Email).MinimumLength(5);
            RuleFor(x => x.Email).MaximumLength(50);
            RuleFor(x => x.Email).EmailAddress();
            RuleFor(x => x.RepeatPassword).Equal(x => x.Password);
        }
    }
}
