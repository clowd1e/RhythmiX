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
            RuleFor(x => x.Email).EmailAddress();
            RuleFor(x => x.RepeatPassword).Equal(x => x.Password);
        }
    }
}
