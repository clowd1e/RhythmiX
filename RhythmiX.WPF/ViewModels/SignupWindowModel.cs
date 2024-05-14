using RhythmiX.Service.Queries.Dtos;
using RhythmiX.WPF.Commands;
using RhythmiX.WPF.Views;
using System.Windows.Input;

namespace RhythmiX.WPF.ViewModels
{
    public class SignupWindowModel : ViewModelBase
    {
        private bool isModalOpen;
        public bool IsModalOpen
        {
            get => isModalOpen;
            set
            {
                isModalOpen = value;
                OnPropertyChanged(nameof(IsModalOpen));
            }
        }

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

        public ICommand Signup { get; }
        public ICommand Cancel { get; }
        public ICommand Confirm { get; }

        public SignupWindowModel()
        {
            registerData = new RegisterDto();
            Signup = new RelayCommand(obj => IsModalOpen = true);

            Cancel = new RelayCommand(obj => IsModalOpen = false);

            Confirm = new AsyncRelayCommand(new Func<object, Task>(OnConfirm));
        }

        private async Task OnConfirm(object obj)
        {
            AsyncRegisterCommand registerCommand = new AsyncRegisterCommand(this, registerData);
            await registerCommand.ExecuteAsync(obj);
        }
    }
}
