using FluentValidation;

namespace RhythmiX.Service.Command.User.Login
{
    public class LoginUserCommandValidator : AbstractValidator<LoginUserCommand>
    {
        public LoginUserCommandValidator()
        {
            RuleFor(x => x.Username).NotEmpty();
            RuleFor(x => x.Username).MinimumLength(3);
            RuleFor(x => x.Username).MaximumLength(50);
            RuleFor(x => x.Password).NotEmpty();
            RuleFor(x => x.Password).MinimumLength(8);
            RuleFor(x => x.Password).MaximumLength(30);
        }
    }
}
