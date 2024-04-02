using RhythmiX.WPF.ViewModels;
using RhythmiX.WPF.Views;
using System.Configuration;
using System.Data;
using System.Windows;

namespace RhythmiX.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow = new LoginWindow()
            {
                DataContext = new LoginWindowModel()
            };
            MainWindow.Show();

            base.OnStartup(e);
        }
    }

}
