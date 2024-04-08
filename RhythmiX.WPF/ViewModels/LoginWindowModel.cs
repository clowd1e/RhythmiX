using RhythmiX.WPF.Commands;
using RhythmiX.WPF.Views;
using System.Windows.Input;

namespace RhythmiX.WPF.ViewModels
{
    public class LoginWindowModel : ViewModelBase
    {
        public ICommand ChangeToSignupForm { get; }
        public LoginWindowModel()
        {
            ChangeToSignupForm = new ChangeWindowCommand(new SignupWindow(), typeof(SignupWindowModel));
        }
    }
}
