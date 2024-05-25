using RhythmiX.WPF.Services;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace RhythmiX.WPF.Components.MusicComponents
{
    /// <summary>
    /// Interaction logic for TrackLayout.xaml
    /// </summary>
    public partial class TrackLayout : UserControl
    {
        public TrackLayout()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty TrackNameProperty =
           DependencyProperty.Register("TrackName", typeof(string), typeof(TrackLayout), new PropertyMetadata("TrackName"));
        public static readonly DependencyProperty TrackImageProperty =
            DependencyProperty.Register("TrackImage", typeof(string), typeof(TrackLayout), new PropertyMetadata("track_image_default.png"));
        public static readonly DependencyProperty TrackArtistProperty =
            DependencyProperty.Register("TrackArtist", typeof(string), typeof(TrackLayout), new PropertyMetadata("TrackArtist"));

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
            artistName.Text = TrackArtist;
        }


        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateTrackName();
            UpdateTrackImage();
            UpdateTrackArtist();
        }
    }
}
