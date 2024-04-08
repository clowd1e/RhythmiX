using RhythmiX.WPF.ViewModels;
using RhythmiX.WPF.Views;
using System.Windows;

namespace RhythmiX.WPF.Commands
{
    public class ChangeToSingupFormCommand : CommandBase
    {
        public override void Execute(object? parameter)
        {
            ChangeWindow();
        }

        private void ChangeWindow()
        {
            SignupWindow mainWindow = new SignupWindow()
            {
                DataContext = new SignupWindowModel()
            };

            Application.Current.MainWindow.Close();
            Application.Current.MainWindow = mainWindow;
            mainWindow.Show();
        }
    }
}
