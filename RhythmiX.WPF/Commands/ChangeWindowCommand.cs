using System.Windows;

namespace RhythmiX.WPF.Commands
{
    public class ChangeWindowCommand : CommandBase
    {
        private readonly Window window;
        private readonly Type type;

        public ChangeWindowCommand(Window window, Type type)
        {
            this.window = window;
            this.type = type;
        }

        public override void Execute(object? parameter)
        {
            ChangeWindow();
        }

        private void ChangeWindow()
        {
            window.DataContext = Activator.CreateInstance(type);
            Application.Current.MainWindow.Close();
            Application.Current.MainWindow = window;
            window.Show();
        }
    }
}
