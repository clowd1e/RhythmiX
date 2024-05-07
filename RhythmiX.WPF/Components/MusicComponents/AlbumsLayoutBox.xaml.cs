using RhythmiX.Service.Queries.Dtos;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace RhythmiX.WPF.Components.MusicComponents
{
    /// <summary>
    /// Interaction logic for AlbumsLayoutBox.xaml
    /// </summary>
    public partial class AlbumsLayoutBox : UserControl
    {
        public AlbumsLayoutBox()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty ItemSourceProperty =
            DependencyProperty.Register("ItemSource", typeof(ObservableCollection<AlbumDto>), typeof(AlbumsLayoutBox), new PropertyMetadata(null));
        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(AlbumsLayoutBox), new PropertyMetadata("Albums"));

        public ObservableCollection<AlbumDto> ItemSource
        {
            get { return (ObservableCollection<AlbumDto>)GetValue(ItemSourceProperty); }
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

            if (listBox.Items.Count == 1)
            {
                var item = (ListBoxItem)listBox.ItemContainerGenerator.ContainerFromIndex(0);
                item.Margin = new Thickness(0, 0, 0, 0);
                return;
            }

            var firstItem = (ListBoxItem)listBox.ItemContainerGenerator.ContainerFromIndex(0);
            if (firstItem is null)
                return;

            var lastItem = (ListBoxItem)listBox.ItemContainerGenerator.ContainerFromIndex(listBox.Items.Count - 1);
            if (lastItem is null)
                return;

            firstItem.Margin = new Thickness(0, 0, 13, 0);
            lastItem.Margin = new Thickness(13, 0, 0, 0);
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
