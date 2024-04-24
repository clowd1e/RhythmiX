using RhythmiX.WPF.Services;
using RhythmiX.WPF.ViewModels;
using System.Windows;
using System.Windows.Controls;
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
            if (checkbox.IsChecked is true && IsEmailAndPasswordNotEmpty(EmailField.Text, PasswordField.Password))
                AuthenticationSettingsHandler.SaveSettings(EmailField.Text, PasswordField.Password);
            else
                AuthenticationSettingsHandler.SaveSettings(string.Empty, string.Empty);
        }

        private bool IsEmailAndPasswordNotEmpty(string email, string password) =>
            !string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password);

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadUserAuthenticationSettings();
        }

        private void LoadUserAuthenticationSettings()
        {
            checkbox.IsChecked = false;
            string email = string.Empty;
            string password = string.Empty;

            AuthenticationSettingsHandler.LoadSettings(out email, out password);

            if (IsEmailAndPasswordNotEmpty(email, password))
                checkbox.IsChecked = true;

            EmailField.Text = email;
            PasswordField.Password = password;
        }
    }
}
