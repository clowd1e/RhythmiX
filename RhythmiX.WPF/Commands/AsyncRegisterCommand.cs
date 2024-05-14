using Cinema.Service;
using RhythmiX.Service.Command.User.Register;
using RhythmiX.Service.Queries.Dtos;
using RhythmiX.Storage;
using RhythmiX.Storage.Repository;
using RhythmiX.WPF.ViewModels;

namespace RhythmiX.WPF.Commands
{
    public class AsyncRegisterCommand : AsyncCommandBase
    {
        private readonly RegisterDto _registerData;
        private readonly SignupWindowModel _signupWindow;
        public AsyncRegisterCommand(SignupWindowModel signupWindow, RegisterDto registerData)
        {
            _signupWindow = signupWindow;
            _registerData = registerData;
        }

        public async override Task ExecuteAsync(object? parameter)
        {
            using (MusicDbContext context = new MusicDbContext())
            {
                UserRepository userRepository = new UserRepository(context);

                RegisterUserCommand command = new RegisterUserCommand(_registerData.Username, _registerData.Password, _registerData.RepeatPassword, _registerData.Email);
                RegisterUserCommandHandler handler = new RegisterUserCommandHandler(userRepository);

                Result result = await handler.HandleAsync(command);
                if (result.IsSuccess)
                {
                    _signupWindow.IsConfirmModalOpen = false;
                    _signupWindow.ResultTitle = "Success!";
                    _signupWindow.IsResultModalOpen = true;
                }
                else
                {
                    _signupWindow.IsConfirmModalOpen = false;

                    Error? usernameError = result.Errors.FirstOrDefault(e => e.PropertyName == "Username");
                    string usernameErrorMessage = usernameError?.Message;

                    Error? emailError = result.Errors.FirstOrDefault(e => e.PropertyName == "Email");
                    string emailErrorMessage = emailError?.Message;

                    Error? passwordError = result.Errors.FirstOrDefault(e => e.PropertyName == "Password");
                    string passwordErrorMessage = passwordError?.Message;

                    Error? repeatPasswordError = result.Errors.FirstOrDefault(e => e.PropertyName == "RepeatPassword");
                    string repeatPasswordErrorMessage = repeatPasswordError?.Message;

                    _signupWindow.UsernameErrorMessage = usernameErrorMessage;
                    _signupWindow.EmailErrorMessage = emailErrorMessage;
                    _signupWindow.PasswordErrorMessage = passwordErrorMessage;
                    _signupWindow.RepeatPasswordErrorMessage = repeatPasswordErrorMessage;
                }
            }
        }
    }
}
