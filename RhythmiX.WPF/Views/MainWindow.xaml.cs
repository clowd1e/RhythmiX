using System.Windows;
using System.Windows.Input;

namespace RhythmiX.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void WindowControlButtons_MinimizeClicked(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void DragableField_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                DragMove();
        }

        private void MusicPlayerBar_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (musicPlayerBar.Visibility == Visibility.Visible)
                accountButton.Margin = new Thickness(0, 125, 0, 0);
            else
                accountButton.Margin = new Thickness(0, 174, 0, 0);
        }
    }
}