using RhythmiX.WPF.Services;
using System.Windows;
using System.Windows.Input;

namespace RhythmiX.WPF.Views
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void WindowControlButtons_MinimizeClicked(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void DragableField_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                DragMove();
        }

        private void labelButton_Click(object sender, RoutedEventArgs e)
        {
            if (checkbox.IsChecked is true)
                checkbox.IsChecked = false;
            else
                checkbox.IsChecked = true;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (checkbox.IsChecked is true && IsUsernameAndPasswordNotEmpty(UsernameField.Text, PasswordField.Password))
                AuthenticationSettingsHandler.SaveSettings(UsernameField.Text, PasswordField.Password);
            else
                AuthenticationSettingsHandler.SaveSettings(string.Empty, string.Empty);
        }

        private bool IsUsernameAndPasswordNotEmpty(string username, string password) =>
            !string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password);

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadUserAuthenticationSettings();
        }

        private void LoadUserAuthenticationSettings()
        {
            checkbox.IsChecked = false;
            string username = string.Empty;
            string password = string.Empty;

            AuthenticationSettingsHandler.LoadSettings(out username, out password);

            if (IsUsernameAndPasswordNotEmpty(username, password))
                checkbox.IsChecked = true;

            UsernameField.Text = username;
            PasswordField.Password = password;
        }
    }
}
