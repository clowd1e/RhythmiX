using RhythmiX.Service.Queries.Dtos;
using RhythmiX.WPF.Commands;
using RhythmiX.WPF.Views;
using System.Windows.Input;

namespace RhythmiX.WPF.ViewModels
{
    public class SignupWindowModel : ViewModelBase
    {
        #region ConfirmModal
        private bool isConfirmModalOpen;
        public bool IsConfirmModalOpen
        {
            get => isConfirmModalOpen;
            set
            {
                isConfirmModalOpen = value;
                OnPropertyChanged(nameof(IsConfirmModalOpen));
            }
        }

        public ICommand Cancel { get; }
        public ICommand Confirm { get; }
        #endregion

        #region ResultModal

        private bool isResultModalOpen;
        public bool IsResultModalOpen
        {
            get => isResultModalOpen;
            set
            {
                isResultModalOpen = value;
                OnPropertyChanged(nameof(IsResultModalOpen));
            }
        }

        private string resultTitle;
        public string ResultTitle
        {
            get => resultTitle;
            set
            {
                resultTitle = value;
                OnPropertyChanged(nameof(ResultTitle));
            }
        }

        public ICommand CloseResultModal { get; }
        #endregion

        #region RegisterData
        private string username;
        public string Username
        {
            get => username;
            set
            {
                username = value;
                OnPropertyChanged(nameof(Username));
                registerData.Username = value;
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
                registerData.Password = value;
            }
        }

        private string repeatPassword;
        public string RepeatPassword
        {
            get => repeatPassword;
            set
            {
                repeatPassword = value;
                OnPropertyChanged(nameof(RepeatPassword));
                registerData.RepeatPassword = value;
            }
        }

        private string email;
        public string Email
        {
            get => email;
            set
            {
                email = value;
                OnPropertyChanged(nameof(Email));
                registerData.Email = value;
            }
        }

        private RegisterDto registerData;
        #endregion

        #region ErrorMessages
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

        private string emailErrorMessage;
        public string EmailErrorMessage
        {
            get => emailErrorMessage;
            set
            {
                emailErrorMessage = value;
                OnPropertyChanged(nameof(EmailErrorMessage));
                OnPropertyChanged(nameof(HasEmailError));
            }
        }

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

        private string repeatPasswordErrorMessage;
        public string RepeatPasswordErrorMessage
        {
            get => repeatPasswordErrorMessage;
            set
            {
                repeatPasswordErrorMessage = value;
                OnPropertyChanged(nameof(RepeatPasswordErrorMessage));
                OnPropertyChanged(nameof(HasRepeatPasswordError));
            }
        }


        public bool HasUsernameError => !string.IsNullOrEmpty(UsernameErrorMessage);
        public bool HasEmailError => !string.IsNullOrEmpty(EmailErrorMessage);
        public bool HasPasswordError => !string.IsNullOrEmpty(PasswordErrorMessage);
        public bool HasRepeatPasswordError => !string.IsNullOrEmpty(RepeatPasswordErrorMessage);
        #endregion

        public ICommand Signup { get; }

        public SignupWindowModel()
        {
            registerData = new RegisterDto();
            Signup = new RelayCommand(obj => IsConfirmModalOpen = true);

            Cancel = new RelayCommand(obj => IsConfirmModalOpen = false);
            Confirm = new AsyncRelayCommand(new Func<object, Task>(OnConfirm));

            CloseResultModal = new ChangeWindowCommand(new LoginWindow(), typeof(LoginWindowModel), new UserDto(registerData.Username, registerData.Password));
        }

        private async Task OnConfirm(object obj)
        {
            AsyncRegisterCommand registerCommand = new AsyncRegisterCommand(this, registerData);
            await registerCommand.ExecuteAsync(obj);
        }
    }
}
