using System.Windows;
using System.Windows.Controls;

namespace RhythmiX.WPF.Components
{
    /// <summary>
    /// Interaction logic for DragableField.xaml
    /// </summary>
    public partial class DragableField : UserControl
    {
        public event RoutedEventHandler FieldDraged;
        public DragableField()
        {
            InitializeComponent();
        }

        private void DragField_MouseDown(object sender, RoutedEventArgs e)
        {
            FieldDraged?.Invoke(this, e);
        }
    }
}
