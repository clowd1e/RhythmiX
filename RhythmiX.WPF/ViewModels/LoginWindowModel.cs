using RhythmiX.WPF.Commands;
using System.Windows.Input;

namespace RhythmiX.WPF.ViewModels
{
    public class LoginWindowModel : ViewModelBase
    {
        public ICommand ChangeToSingupForm { get; }
        public LoginWindowModel()
        {
            ChangeToSingupForm = new ChangeToSingupFormCommand();
        }
    }
}
