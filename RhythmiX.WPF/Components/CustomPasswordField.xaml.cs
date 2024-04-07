using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
    }
}
