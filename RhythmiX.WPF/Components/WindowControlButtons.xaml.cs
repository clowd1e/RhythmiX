using System.Windows;
using System.Windows.Controls;

namespace RhythmiX.WPF.Components
{
    /// <summary>
    /// Interaction logic for WindowControlButtons.xaml
    /// </summary>
    public partial class WindowControlButtons : UserControl
    {
        public event RoutedEventHandler MinimizeClicked;

        public WindowControlButtons()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            MinimizeClicked?.Invoke(this, e);
        }
    }
}
