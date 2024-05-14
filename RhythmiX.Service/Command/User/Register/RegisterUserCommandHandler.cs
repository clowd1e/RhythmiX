using Cinema.Service;
using FluentValidation.Results;
using RhythmiX.Storage.Repository;
using Entity = RhythmiX.Storage.Entities;

namespace RhythmiX.Service.Command.User.Register
{
    public class RegisterUserCommandHandler : ICommandHandler<RegisterUserCommand>
    {
        private readonly IUserRepository _userRepository;
        public RegisterUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Result> HandleAsync(RegisterUserCommand command)
        {
            ValidationResult validationResult = new RegisterUserCommandValidator().Validate(command);
            if (!validationResult.IsValid)
                return Result.Fail(validationResult);

            if (await _userRepository.IsUsernameTakenAsync(command.Username))
                return Result.Fail("Username is already taken", nameof(command.Username));

            Entity.User user = new Entity.User(command.Username, command.Password, command.Email);
            await _userRepository.AddUserAsync(user);

            return Result.Ok();
        }
    }
}
