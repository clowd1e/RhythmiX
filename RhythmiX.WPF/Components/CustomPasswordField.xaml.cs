using System.Windows;
using System.Windows.Controls;

namespace RhythmiX.WPF.Components
{
    /// <summary>
    /// Interaction logic for CustomPasswordField.xaml
    /// </summary>
    public partial class CustomPasswordField : UserControl
    {
        public CustomPasswordField()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty LabelTextProperty =
           DependencyProperty.Register("LabelText", typeof(string), typeof(CustomPasswordField), new PropertyMetadata("Label"));

        public static readonly DependencyProperty PlaceholderTextProperty =
            DependencyProperty.Register("PlaceholderText", typeof(string), typeof(CustomPasswordField), new PropertyMetadata("Default placeholder"));

        public string LabelText
        {
            get { return (string)GetValue(LabelTextProperty); }
            set { SetValue(LabelTextProperty, value); }
        }

        public string PlaceholderText
        {
            get { return (string)GetValue(PlaceholderTextProperty); }
            set { SetValue(PlaceholderTextProperty, value); }
        }

        private void UpdateLabel()
        {
            labelText.Text = LabelText;
        }

        private void UpdatePlaceholderText()
        {
            placeholder.Text = PlaceholderText;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateLabel();
            UpdatePlaceholderText();
        }


        private bool isPasswordChanging;

        public string Password
        {
            get { return (string)GetValue(PasswordProperty); }
            set { SetValue(PasswordProperty, value); }
        }

        private void customPasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            isPasswordChanging = true;
            Password = customPasswordBox.Password;
            isPasswordChanging = false;
        }


        public static readonly DependencyProperty PasswordProperty =
            DependencyProperty.Register("Password", typeof(string), typeof(CustomPasswordField), new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, PasswordPropertyChanged));

        private static void PasswordPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is CustomPasswordField passwordBox)
                passwordBox.UpdatePassword();
        }

        private void UpdatePassword()
        {
            if (!isPasswordChanging)
                customPasswordBox.Password = Password;

            if (Password == "")
                placeholder.Visibility = Visibility.Visible;
            else
                placeholder.Visibility = Visibility.Collapsed;
        }
    }
}
