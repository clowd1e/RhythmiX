using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace RhythmiX.WPF.Components
{
    /// <summary>
    /// Interaction logic for MenuButtonComponent.xaml
    /// </summary>
    public partial class MenuButtonComponent : UserControl
    {
        public MenuButtonComponent()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register("Command", typeof(ICommand), typeof(MenuButtonComponent), new PropertyMetadata(null));
        public static readonly DependencyProperty CheckedProperty =
            DependencyProperty.Register("IsChecked", typeof(bool), typeof(MenuButtonComponent), new PropertyMetadata(false));
        public static readonly DependencyProperty IconProperty =
            DependencyProperty.Register("Icon", typeof(string), typeof(MenuButtonComponent), new PropertyMetadata("default_main.png"));
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(MenuButtonComponent), new PropertyMetadata("Default text"));

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        public bool IsChecked
        {
            get { return (bool)GetValue(CheckedProperty); }
            set { SetValue(CheckedProperty, value); }
        }

        public string Icon
        {
            get { return (string)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        private void UpdateIcon()
        {
            BitmapImage buttonIcon = new BitmapImage(new System.Uri($"../../../Images/{Icon}", System.UriKind.Relative));
            buttonIcon.CacheOption = BitmapCacheOption.OnLoad;

            icon.Source = buttonIcon;
        }

        private void UpdateText()
        {
            text.Text = Text;
        }

        private void UpdateCommand()
        {
            MenuButton.Command = Command;
        }

        private void UpdateChecked()
        {
            MenuButton.IsChecked = IsChecked;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateIcon();
            UpdateText();
            UpdateCommand();
            UpdateChecked();
        }
    }
}
