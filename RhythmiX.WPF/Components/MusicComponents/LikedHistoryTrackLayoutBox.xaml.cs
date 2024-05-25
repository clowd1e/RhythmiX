using RhythmiX.Service.Queries.Dtos;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace RhythmiX.WPF.Components.MusicComponents
{
    /// <summary>
    /// Interaction logic for LikedHistoryTrackLayoutBox.xaml
    /// </summary>
    public partial class LikedHistoryTrackLayoutBox : UserControl
    {
        public LikedHistoryTrackLayoutBox()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty ItemSourceProperty =
            DependencyProperty.Register("ItemSource", typeof(ObservableCollection<TrackDto>), typeof(LikedHistoryTrackLayoutBox), new PropertyMetadata(null));

        public ObservableCollection<TrackDto> ItemSource
        {
            get { return (ObservableCollection<TrackDto>)GetValue(ItemSourceProperty); }
            set { SetValue(ItemSourceProperty, value); }
        }

        private void UpdateItemSource()
        {
            listBox.ItemsSource = ItemSource;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateItemSource();
        }

        private void listBox_Loaded(object sender, RoutedEventArgs e)
        {
            if (listBox.Items.Count <= 1)
                return;

            var lastItem = (ListBoxItem)listBox.ItemContainerGenerator.ContainerFromIndex(listBox.Items.Count - 1);
            if (lastItem is null)
                return;

            var lastItemLayout = (LikedHistoryTrackLayout)lastItem.Content;
            if (lastItemLayout is null)
                return;

            lastItemLayout.HasBottomBorder = false;
        }

        private void listBox_PreviewMouseWheel(object sender, System.Windows.Input.MouseWheelEventArgs e)
        {
            ScrollViewer scrollViewer = GetParentScrollViewer((DependencyObject)sender);

            if (scrollViewer != null)
            {
                if (e.Delta < 0)
                {
                    scrollViewer.LineDown();
                }
                else
                {
                    scrollViewer.LineUp();
                }

                e.Handled = true;
            }
        }

        private ScrollViewer GetParentScrollViewer(DependencyObject child)
        {
            DependencyObject parent = VisualTreeHelper.GetParent(child);

            while (parent != null && !(parent is ScrollViewer))
            {
                parent = VisualTreeHelper.GetParent(parent);
            }

            return parent as ScrollViewer;
        }
    }
}
