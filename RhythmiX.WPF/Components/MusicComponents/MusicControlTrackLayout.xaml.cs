using RhythmiX.WPF.Services;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace RhythmiX.WPF.Components.MusicComponents
{
    /// <summary>
    /// Interaction logic for MusicControlTrackLayout.xaml
    /// </summary>
    public partial class MusicControlTrackLayout : UserControl
    {
        public MusicControlTrackLayout()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty TrackNameProperty =
            DependencyProperty.Register("TrackName", typeof(string), typeof(MusicControlTrackLayout), new PropertyMetadata("TrackName"));
        public static readonly DependencyProperty TrackImageProperty =
            DependencyProperty.Register("TrackImage", typeof(string), typeof(MusicControlTrackLayout), new PropertyMetadata("track_image_default.png"));
        public static readonly DependencyProperty TrackArtistProperty =
            DependencyProperty.Register("TrackArtist", typeof(string), typeof(MusicControlTrackLayout), new PropertyMetadata("TrackArtist"));
        public static readonly DependencyProperty TrackDurationProperty =
            DependencyProperty.Register("TrackDuration", typeof(string), typeof(MusicControlTrackLayout), new PropertyMetadata("TrackDuration"));

        public string TrackName
        {
            get { return (string)GetValue(TrackNameProperty); }
            set { SetValue(TrackNameProperty, value); }
        }

        public string TrackImage
        {
            get { return (string)GetValue(TrackImageProperty); }
            set { SetValue(TrackImageProperty, value); }
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

        private void UpdateTrackName()
        {
            trackName.Text = TrackName;
        }

        private void UpdateTrackImage()
        {
            if (!File.Exists($"{PathService.DownloadedTracksPath}/{TrackName}/{TrackImage}"))
            {
                BitmapImage image = new BitmapImage(new Uri(PathService.TrackDefaultImagePath, UriKind.Relative));
                image.CacheOption = BitmapCacheOption.OnLoad;

                trackImage.ImageSource = image;
            }
            else
            {
                BitmapImage image = new BitmapImage(new Uri($"{PathService.DownloadedTracksPath}/{TrackName}/{TrackImage}", UriKind.Relative));
                image.CacheOption = BitmapCacheOption.OnLoad;

                trackImage.ImageSource = image;
            }
        }

        private void UpdateTrackArtist()
        {
            trackArtist.Text = TrackArtist;
        }

        private void UpdateTrackDuration()
        {
            trackDuration.Text = TrackDuration;
        }

        private void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            UpdateTrackName();
            UpdateTrackImage();
            UpdateTrackArtist();
            UpdateTrackDuration();
        }
    }
}
