using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace RhythmiX.WPF.Components.MusicComponents
{
    /// <summary>
    /// Interaction logic for AlbumLayout.xaml
    /// </summary>
    public partial class AlbumLayout : UserControl
    {
        public AlbumLayout()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty AlbumNameProperty =
           DependencyProperty.Register("AlbumName", typeof(string), typeof(AlbumLayout), new PropertyMetadata("AlbumName"));
        public static readonly DependencyProperty AlbumImageProperty =
            DependencyProperty.Register("AlbumImage", typeof(string), typeof(AlbumLayout), new PropertyMetadata("album_image_default.png"));
        public static readonly DependencyProperty AlbumArtistProperty =
            DependencyProperty.Register("AlbumArtist", typeof(string), typeof(AlbumLayout), new PropertyMetadata("AlbumArtist"));

        public string AlbumName
        {
            get { return (string)GetValue(AlbumNameProperty); }
            set { SetValue(AlbumNameProperty, value); }
        }

        public string AlbumImage
        {
            get { return (string)GetValue(AlbumImageProperty); }
            set { SetValue(AlbumImageProperty, value); }
        }

        public string AlbumArtist
        {
            get { return (string)GetValue(AlbumArtistProperty); }
            set { SetValue(AlbumArtistProperty, value); }
        }

        private void UpdateAlbumName()
        {
            albumName.Text = AlbumName;
        }

        private void UpdateAlbumImage()
        {
            BitmapImage image = new BitmapImage(new Uri($"../../../APICallResults/DownloadedAlbums/{AlbumImage}", UriKind.Relative));
            image.CacheOption = BitmapCacheOption.OnLoad;

            albumImage.ImageSource = image;
        }

        private void UpdateAlbumArtist()
        {
            artistName.Text = AlbumArtist;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateAlbumName();
            UpdateAlbumImage();
            UpdateAlbumArtist();
        }
    }
}
