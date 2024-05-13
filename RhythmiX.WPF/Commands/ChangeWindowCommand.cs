using Entity = RhythmiX.Storage.Entities;
using System.Windows;

namespace RhythmiX.WPF.Commands
{
    public class ChangeWindowCommand : CommandBase
    {
        private readonly Window _window;
        private readonly Type _type;
        private readonly Entity.User _user;

        public ChangeWindowCommand(Window window, Type type, Entity.User user = null)
        {
            _window = window;
            _type = type;
            _user = user;
        }

        public override void Execute(object? parameter)
        {
            ChangeWindow();
        }

        private void ChangeWindow()
        {
            _window.DataContext = Activator.CreateInstance(_type, _user);
            Application.Current.MainWindow.Close();
            Application.Current.MainWindow = _window;
            _window.Show();
        }
    }
}
