using System.Windows;
using System.Windows.Controls;

namespace WPFModalControl
{
    public class Modal : ContentControl
    {
        public static readonly DependencyProperty IsOpenProperty = 
            DependencyProperty.Register("IsOpen", typeof(bool), typeof(Modal), new PropertyMetadata(false));

        public static readonly DependencyProperty CornerRadiusProperty = 
            DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(Modal), new PropertyMetadata(new CornerRadius(0)));

        public bool IsOpen
        {
            get { return (bool)GetValue(IsOpenProperty); }
            set { SetValue(IsOpenProperty, value); }
        }

        public CornerRadius CornerRadius
        {
            get { return (CornerRadius)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        static Modal()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Modal), new FrameworkPropertyMetadata(typeof(Modal)));
        }
    }
}
