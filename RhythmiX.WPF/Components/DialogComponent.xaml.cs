using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace RhythmiX.WPF.Components
{
    /// <summary>
    /// Interaction logic for DialogComponent.xaml
    /// </summary>
    public partial class DialogComponent : UserControl
    {
        public DialogComponent()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(DialogComponent), new PropertyMetadata("Title"));

        public static readonly DependencyProperty CloseCommandProperty =
            DependencyProperty.Register("CloseCommand", typeof(ICommand), typeof(DialogComponent), new PropertyMetadata(null));

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public ICommand CloseCommand
        {
            get { return (ICommand)GetValue(CloseCommandProperty); }
            set { SetValue(CloseCommandProperty, value); }
        }

        private void UpdateText()
        {
            title.Text = Title;
        }

        private void UpdateCommand()
        {
            close.Command = CloseCommand;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateText();
            UpdateCommand();
        }
    }
}
