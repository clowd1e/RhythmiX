using RhythmiX.Service.Queries.Dtos;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace RhythmiX.WPF.Components.MusicComponents
{
    /// <summary>
    /// Interaction logic for MusicControlTrackLayoutBox.xaml
    /// </summary>
    public partial class MusicControlTrackLayoutBox : UserControl
    {
        public MusicControlTrackLayoutBox()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty ItemSourceProperty =
            DependencyProperty.Register("ItemSource", typeof(ObservableCollection<TrackDto>), typeof(MusicControlTrackLayoutBox), new PropertyMetadata(null));
        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(MusicControlTrackLayoutBox), new PropertyMetadata("Title"));

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
    }
}
