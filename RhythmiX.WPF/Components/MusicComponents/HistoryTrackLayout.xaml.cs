using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace RhythmiX.WPF.Components
{
    /// <summary>
    /// Interaction logic for HistoryTrackLayout.xaml
    /// </summary>
    public partial class HistoryTrackLayout : UserControl
    {
        public HistoryTrackLayout()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty TrackNameProperty =
            DependencyProperty.Register("TrackName", typeof(string), typeof(HistoryTrackLayout), new PropertyMetadata("TrackName"));

        public static readonly DependencyProperty TrackArtistProperty =
            DependencyProperty.Register("TrackArtist", typeof(string), typeof(HistoryTrackLayout), new PropertyMetadata("TrackArtist"));

        public static readonly DependencyProperty TrackDurationProperty =
            DependencyProperty.Register("TrackDuration", typeof(string), typeof(HistoryTrackLayout), new PropertyMetadata("TrackDuration"));

        public static readonly DependencyProperty TrackImageProperty =
            DependencyProperty.Register("TrackImage", typeof(string), typeof(HistoryTrackLayout), new PropertyMetadata("track_image_default.png"));

        public static readonly DependencyProperty HasBottomBorderProperty =
            DependencyProperty.Register("HasBottomBorder", typeof(bool), typeof(HistoryTrackLayout), new PropertyMetadata(true));

        public string TrackName
        {
            get { return (string)GetValue(TrackNameProperty); }
            set { SetValue(TrackNameProperty, value); }
        }

        public string TrackArtist
        {
            get { return (string)GetValue(TrackArtistProperty); }
            set { SetValue(TrackArtistProperty, value); }
        }

        public string TrackDuration
        {
            get { return (string)GetValue(TrackDurationProperty); }
            set { SetValue(TrackDurationProperty, value); }
        }

        public string TrackImage
        {
            get { return (string)GetValue(TrackImageProperty); }
            set { SetValue(TrackImageProperty, value); }
        }

        public bool HasBottomBorder
        {
            get { return (bool)GetValue(HasBottomBorderProperty); }
            set { SetValue(HasBottomBorderProperty, value); }
        }

        private void UpdateTrackName()
        {
            trackName.Text = TrackName;
        }

        private void UpdateTrackArtist()
        {
            trackArtist.Text = TrackArtist;
        }

        private void UpdateTrackDuration()
        {
            trackDuration.Text = TrackDuration;
        }

        private void UpdateTrackImage()
        {
            BitmapImage image = new BitmapImage(new Uri($"../../../APICallResults/DownloadedMusic/{TrackImage}", UriKind.Relative));
            image.CacheOption = BitmapCacheOption.OnLoad;

            trackImage.ImageSource = image;
        }

        private void UpdateHasBottomBorder()
        {
            if (HasBottomBorder)
                trackLayout.BorderThickness = new Thickness(0, 0, 0, 1);
            else
                trackLayout.BorderThickness = new Thickness(0);
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateTrackName();
            UpdateTrackArtist();
            UpdateTrackDuration();
            UpdateTrackImage();
            UpdateHasBottomBorder();
        }
    }
}
