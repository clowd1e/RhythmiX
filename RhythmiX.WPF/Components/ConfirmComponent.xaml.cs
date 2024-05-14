using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace RhythmiX.WPF.Components
{
    /// <summary>
    /// Interaction logic for ConfirmComponent.xaml
    /// </summary>
    public partial class ConfirmComponent : UserControl
    {
        public ConfirmComponent()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty TitleProperty = 
            DependencyProperty.Register("Title", typeof(string), typeof(ConfirmComponent), new PropertyMetadata("Title"));

        public static readonly DependencyProperty CancelCommandProperty = 
            DependencyProperty.Register("CancelCommand", typeof(ICommand), typeof(ConfirmComponent), new PropertyMetadata(null));

        public static readonly DependencyProperty ConfirmCommandProperty =
            DependencyProperty.Register("ConfirmCommand", typeof(ICommand), typeof(ConfirmComponent), new PropertyMetadata(null));

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public ICommand CancelCommand
        {
            get { return (ICommand)GetValue(CancelCommandProperty); }
            set { SetValue(CancelCommandProperty, value); }
        }

        public ICommand ConfirmCommand
        {
            get { return (ICommand)GetValue(ConfirmCommandProperty); }
            set { SetValue(ConfirmCommandProperty, value); }
        }

        private void UpdateText()
        {
            title.Text = Title;
        }

        private void UpdateCommands()
        {
            cancel.Command = CancelCommand;
            confirm.Command = ConfirmCommand;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateText();
            UpdateCommands();
        }
    }
}
