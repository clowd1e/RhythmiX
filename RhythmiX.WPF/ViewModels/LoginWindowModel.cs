using RhythmiX.Storage.Entities;
using RhythmiX.WPF.Commands;
using RhythmiX.WPF.Views;
using System.Windows.Input;

namespace RhythmiX.WPF.ViewModels
{
    public class LoginWindowModel : ViewModelBase
    {
        private string username;
        public string Username
        {
            get => username;
            set
            {
                username = value;
                OnPropertyChanged(nameof(Username));
                _user.Username = value;
            }
        }

        private string password;
        public string Password
        {
            get => password;
            set
            {
                password = value;
                OnPropertyChanged(nameof(Password));
                _user.Password = value;
            }
        }

        private readonly User _user;

        private string usernameErrorMessage;
        public string UsernameErrorMessage
        {
            get => usernameErrorMessage;
            set
            {
                usernameErrorMessage = value;
                OnPropertyChanged(nameof(UsernameErrorMessage));
                OnPropertyChanged(nameof(HasUsernameError));
            }
        }

        public bool HasUsernameError => !string.IsNullOrEmpty(UsernameErrorMessage);


        private string passwordErrorMessage;
        public string PasswordErrorMessage
        {
            get => passwordErrorMessage;
            set
            {
                passwordErrorMessage = value;
                OnPropertyChanged(nameof(PasswordErrorMessage));
                OnPropertyChanged(nameof(HasPasswordError));
            }
        }

        public bool HasPasswordError => !string.IsNullOrEmpty(PasswordErrorMessage);


        public ICommand ChangeToSignupForm { get; }
        public ICommand Login { get; }
        public LoginWindowModel()
        {
            _user = new User("", "");
            ChangeToSignupForm = new ChangeWindowCommand(new SignupWindow(), typeof(SignupWindowModel));
            Login = new AsyncLoginCommand(_user, this);
        }
    }
}
