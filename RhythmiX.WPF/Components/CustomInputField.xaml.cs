using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Xml;

namespace RhythmiX.WPF.Components
{
    /// <summary>
    /// Interaction logic for CustomInputField.xaml
    /// </summary>
    public partial class CustomInputField : UserControl
    {

        public static readonly DependencyProperty LabelTextProperty =
            DependencyProperty.Register("LabelText", typeof(string), typeof(CustomInputField), new PropertyMetadata("Label"));

        public static readonly DependencyProperty TextBoxBackImageProperty =
            DependencyProperty.Register("TextBoxBackImage", typeof(string), typeof(CustomInputField), new PropertyMetadata("default.png"));

        public static readonly DependencyProperty PlaceholderTextProperty =
            DependencyProperty.Register("PlaceholderText", typeof(string), typeof(CustomInputField), new PropertyMetadata("Default placeholder"));
        
        public string LabelText
        {
            get { return (string)GetValue(LabelTextProperty); }
            set { SetValue(LabelTextProperty, value); }
        }

        public string TextBoxBackImage
        {
            get { return (string)GetValue(TextBoxBackImageProperty); }
            set { SetValue(TextBoxBackImageProperty, value); }
        }

        public string PlaceholderText
        {
            get { return (string)GetValue(PlaceholderTextProperty); }
            set { SetValue(PlaceholderTextProperty, value); }
        }

        public CustomInputField()
        {
            InitializeComponent();
        }

        private void UpdateLabel()
        {
            labelText.Text = LabelText;
        }

        private void UpdateTextBoxBackgroungImage()
        {
            BitmapImage textBoxBackImage = new BitmapImage(new Uri($"../../../Images/{TextBoxBackImage}", UriKind.Relative));
            textBoxBackImage.CacheOption = BitmapCacheOption.OnLoad;

            customTextBoxBackImage.ImageSource = textBoxBackImage;
        }

        private void UpdatePlaceholderText()
        {
            Placeholder.Text = PlaceholderText;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateLabel();
            UpdateTextBoxBackgroungImage();
            UpdatePlaceholderText();
        }
    }
}
