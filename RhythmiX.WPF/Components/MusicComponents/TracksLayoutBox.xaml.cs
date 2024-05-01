using RhythmiX.Service.Queries.Dtos;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

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
                
            }
        }
    }
}
