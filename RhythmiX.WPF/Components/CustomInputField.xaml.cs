using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace RhythmiX.WPF.Components
{
    /// <summary>
    /// Interaction logic for CustomInputField.xaml
    /// </summary>
    public partial class CustomInputField : UserControl
    {
        public CustomInputField()
        {
            InitializeComponent();
        }

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




        private bool isTextChanging;

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        private void customTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            isTextChanging = true;
            Text = customTextBox.Text;
            isTextChanging = false;
        }

        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(CustomInputField), new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, TextPropertyChanged));

        private static void TextPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is CustomInputField customTextBox)
                customTextBox.UpdateText();
        }

        private void UpdateText()
        {
            if (!isTextChanging)
                customTextBox.Text = Text;
        }
    }
}
