using Cinema.Service;
using RhythmiX.Service.Command.User.Login;
using RhythmiX.Service.Queries.Dtos;
using RhythmiX.Service.Queries.User;
using RhythmiX.Storage;
using RhythmiX.Storage.Entities;
using RhythmiX.Storage.Repository;
using RhythmiX.WPF.ViewModels;
using System.Windows.Input;

namespace RhythmiX.WPF.Commands
{
    public class AsyncLoginCommand : AsyncCommandBase
    {
        private readonly UserDto _userInitials;
        private readonly LoginWindowModel _loginWindowModel;
        public AsyncLoginCommand(UserDto userInitials, LoginWindowModel loginWindowModel)
        {
            _userInitials = userInitials;
            _loginWindowModel = loginWindowModel;
        }

        public async override Task ExecuteAsync(object? parameter)
        {
            using (MusicDbContext context = new MusicDbContext())
            {
                UserRepository userRepository = new UserRepository(context);

                LoginUserCommand command = new LoginUserCommand(_userInitials.Username, _userInitials.Password);
                LoginUserCommandHandler handler = new LoginUserCommandHandler(userRepository);

                Result result = await handler.HandleAsync(command);
                if (result.IsSuccess)
                {
                    GetUserQuery userQuery = new GetUserQuery();
                    GetUserQueryHandler userQueryHandler = new GetUserQueryHandler(userRepository, _userInitials);
                    User user = await userQueryHandler.HandleAsync(userQuery);

                    ICommand changeWindowCommand = new ChangeWindowCommand(new MainWindow(), typeof(MainWindowModel), user);
                    changeWindowCommand.Execute(null);
                }
                else
                {
                    
                    Error? usernameError = result.Errors.FirstOrDefault(e => e.PropertyName == "Username");
                    string usernameErrorMessage = usernameError?.Message;
                    Error? passwordError = result.Errors.FirstOrDefault(e => e.PropertyName == "Password");
                    string passwordErrorMessage = passwordError?.Message;

                    _loginWindowModel.UsernameErrorMessage = usernameErrorMessage;
                    _loginWindowModel.PasswordErrorMessage = passwordErrorMessage;
                }
            }
        }
    }
}
