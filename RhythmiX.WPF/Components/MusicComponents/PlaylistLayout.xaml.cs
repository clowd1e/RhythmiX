using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace RhythmiX.WPF.Components.MusicComponents
{
    /// <summary>
    /// Interaction logic for PlaylistLayout.xaml
    /// </summary>
    public partial class PlaylistLayout : UserControl
    {
        public PlaylistLayout()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty PlaylistNameProperty =
            DependencyProperty.Register("PlaylistName", typeof(string), typeof(PlaylistLayout), new PropertyMetadata("PlaylistName"));
        public static readonly DependencyProperty PlaylistImageProperty =
            DependencyProperty.Register("PlaylistImage", typeof(string), typeof(PlaylistLayout), new PropertyMetadata("playlist_image_default.png"));
        public static readonly DependencyProperty PlaylistArtistProperty =
            DependencyProperty.Register("PlaylistArtist", typeof(string), typeof(PlaylistLayout), new PropertyMetadata("PlaylistArtist"));

        public string PlaylistName
        {
            get { return (string)GetValue(PlaylistNameProperty); }
            set { SetValue(PlaylistNameProperty, value); }
        }

        public string PlaylistImage
        {
            get { return (string)GetValue(PlaylistImageProperty); }
            set { SetValue(PlaylistImageProperty, value); }
        }

        public string PlaylistArtist
        {
            get { return (string)GetValue(PlaylistArtistProperty); }
            set { SetValue(PlaylistArtistProperty, value); }
        }

        private void UpdatePlaylistName()
        {
            playlistName.Text = PlaylistName;
        }

        private void UpdatePlaylistImage()
        {
            BitmapImage image = new BitmapImage(new Uri($"../../../APICallResults/DownloadedPlaylists/{PlaylistImage}", UriKind.Relative));
            image.CacheOption = BitmapCacheOption.OnLoad;

            playlistImage.ImageSource = image;
        }

        private void UpdatePlaylistArtist()
        {
            artistName.Text = PlaylistArtist;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            UpdatePlaylistName();
            UpdatePlaylistImage();
            UpdatePlaylistArtist();
        }
    }
}
