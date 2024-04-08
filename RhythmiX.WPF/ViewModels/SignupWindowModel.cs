using RhythmiX.WPF.Commands;
using RhythmiX.WPF.Views;
using System.Windows.Input;

namespace RhythmiX.WPF.ViewModels
{
    public class SignupWindowModel : ViewModelBase
    {
        public ICommand ChangeToLoginForm { get; }
        public SignupWindowModel()
        {
            ChangeToLoginForm = new ChangeWindowCommand(new LoginWindow(), typeof(LoginWindowModel));
        }
    }
}
