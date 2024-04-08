using RhythmiX.WPF.ViewModels;
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
    }
}
