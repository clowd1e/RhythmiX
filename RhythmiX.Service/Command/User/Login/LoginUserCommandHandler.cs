using Cinema.Service;
using FluentValidation.Results;
using RhythmiX.Storage.Repository;

namespace RhythmiX.Service.Command.User.Login
{
    public class LoginUserCommandHandler : ICommandHandler<LoginUserCommand>
    {
        private readonly IUserRepository _userRepository;
        public LoginUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<Result> HandleAsync(LoginUserCommand command)
        {
            ValidationResult validationResult = new LoginUserCommandValidator().Validate(command);
            if (!validationResult.IsValid)
                return Result.Fail(validationResult);

            if (!await _userRepository.IsUserExistsAsync(command.Username))
                return Result.Fail("User does not exist", nameof(command.Username));

            if (!await _userRepository.IsPasswordCorrectAsync(command.Username, command.Password))
                return Result.Fail("Password is incorrect", nameof(command.Password));

            return Result.Ok();
        }
    }
}
