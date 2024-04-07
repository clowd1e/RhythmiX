using System.Windows;
using System.Windows.Controls;

namespace RhythmiX.WPF.Components
{
    /// <summary>
    /// Interaction logic for BindablePasswordBox.xaml
    /// </summary>
    public partial class BindablePasswordBox : UserControl
    {
        public BindablePasswordBox()
        {
            InitializeComponent();
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
            DependencyProperty.Register("Password", typeof(string), typeof(BindablePasswordBox), new PropertyMetadata(string.Empty, PasswordPropertyChanged));

        private static void PasswordPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is BindablePasswordBox passwordBox)
            {
                passwordBox.UpdatePassword();
            }
        }

        private void UpdatePassword()
        {
            if (!isPasswordChanging)
            {
                customPasswordBox.Password = Password;
            }
        }
    }
}
