using RhythmiX.Service.Queries.Dtos;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace RhythmiX.WPF.Components.MusicComponents
{
    /// <summary>
    /// Interaction logic for TracksLayoutBox.xaml
    /// </summary>
    public partial class TracksLayoutBox : UserControl
    {
        public TracksLayoutBox()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty ItemSourceProperty =
            DependencyProperty.Register("ItemSource", typeof(ObservableCollection<TrackDto>), typeof(TracksLayoutBox), new PropertyMetadata(null));
        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(TracksLayoutBox), new PropertyMetadata("Tracks"));

        public ObservableCollection<TrackDto> ItemSource
        {
            get { return (ObservableCollection<TrackDto>)GetValue(ItemSourceProperty); }
            set { SetValue(ItemSourceProperty, value); }
        }

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        private void UpdateItemSource()
        {
            listBox.ItemsSource = ItemSource;
        }

        private void UpdateTitle()
        {
            title.Text = Title;
        }


        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateItemSource();
            UpdateTitle();
        }

        private void listBox_Loaded(object sender, RoutedEventArgs e)
        {
            if (listBox.Items.Count <= 0)
                return;

            for (int i = 0; i < listBox.Items.Count; i++)
            {
                var item = (ListBoxItem)listBox.ItemContainerGenerator.ContainerFromIndex(i);
                double horizontal = 4.5;
                double vertical = 3;
                if (i % 3 != 0)
                    item.Margin = new Thickness(horizontal, item.Margin.Top, item.Margin.Right, item.Margin.Bottom);
                if (i > 2)
                    item.Margin = new Thickness(item.Margin.Left, vertical, item.Margin.Right, item.Margin.Bottom);
                if ((i + 1) % 3 != 0)
                    item.Margin = new Thickness(item.Margin.Left, item.Margin.Top, horizontal, item.Margin.Bottom);
                if (i < 6)
                    item.Margin = new Thickness(item.Margin.Left, item.Margin.Top, item.Margin.Right, vertical);
            }
        }

        private void ListBox_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
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
