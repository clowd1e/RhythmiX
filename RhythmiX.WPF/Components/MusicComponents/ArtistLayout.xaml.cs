using RhythmiX.WPF.Services;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace RhythmiX.WPF.Components.MusicComponents
{
    /// <summary>
    /// Interaction logic for ArtistLayout.xaml
    /// </summary>
    public partial class ArtistLayout : UserControl
    {
        public ArtistLayout()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty ArtistNameProperty =
            DependencyProperty.Register("ArtistName", typeof(string), typeof(ArtistLayout), new PropertyMetadata("ArtistName"));
        public static readonly DependencyProperty ArtistImageProperty =
            DependencyProperty.Register("ArtistImage", typeof(string), typeof(ArtistLayout), new PropertyMetadata("artist_image_default.png"));

        public string ArtistName
        {
            get { return (string)GetValue(ArtistNameProperty); }
            set { SetValue(ArtistNameProperty, value); }
        }

        public string ArtistImage
        {
            get { return (string)GetValue(ArtistImageProperty); }
            set { SetValue(ArtistImageProperty, value); }
        }

        private void UpdateArtistName()
        {
            artistName.Text = ArtistName;
        }

        private void UpdateArtistImage()
        {
            BitmapImage image = new BitmapImage(new Uri($"{PathService.DownloadedArtistsPath}/{ArtistImage}", UriKind.Relative));
            image.CacheOption = BitmapCacheOption.OnLoad;

            artistImage.ImageSource = image;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateArtistName();
            UpdateArtistImage();
        }
    }
}
