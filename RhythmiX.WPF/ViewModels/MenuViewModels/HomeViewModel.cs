using RhythmiX.Service.Queries.Dtos;
using System.Collections.ObjectModel;

namespace RhythmiX.WPF.ViewModels.MenuViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        private ObservableCollection<AlbumDto> albums = new ObservableCollection<AlbumDto>() { 
            new AlbumDto() { AlbumName = "Album 1", ArtistName = "Artist 1", Image = "album_image_default.jpg" },
            new AlbumDto() { AlbumName = "Album 2", ArtistName = "Artist 2", Image = "album_image_default.jpg" },
            new AlbumDto() { AlbumName = "Album 3", ArtistName = "Artist 3", Image = "album_image_default.jpg" },
            new AlbumDto() { AlbumName = "Album 4", ArtistName = "Artist 4", Image = "album_image_default.jpg" }
        };

        private ObservableCollection<TrackDto> tracks = new ObservableCollection<TrackDto>()
        {
            new TrackDto() { TrackName = "Track 1", ArtistName = "Artist 1", Image = "track_image_default.jpg" },
            new TrackDto() { TrackName = "Track 2", ArtistName = "Artist 2", Image = "track_image_default.jpg" },
            new TrackDto() { TrackName = "Track 3", ArtistName = "Artist 3", Image = "track_image_default.jpg" },
            new TrackDto() { TrackName = "Really cool song", ArtistName = "NIRVANA", Image = "Nirvana.jpg" },
            new TrackDto() { TrackName = "Track 5", ArtistName = "Artist 5", Image = "track_image_default.jpg" },
            new TrackDto() { TrackName = "Track 6", ArtistName = "Artist 6", Image = "track_image_default.jpg" },
            new TrackDto() { TrackName = "I need really long song name", ArtistName = "Long group name so that it's really long", Image = "NWA.jpg" },
            new TrackDto() { TrackName = "Track 8", ArtistName = "Artist 8", Image = "track_image_default.jpg" },
            new TrackDto() { TrackName = "Track 9", ArtistName = "Artist 9", Image = "track_image_default.jpg" }
        };

        private ObservableCollection<ArtistDto> artists = new ObservableCollection<ArtistDto>()
        {
            new ArtistDto() { ArtistName = "NEFFEX", Image = "Neffex.jpg" },
            new ArtistDto() { ArtistName = "Metallica", Image = "Metallica.jpg" },
            new ArtistDto() { ArtistName = "AC/DC", Image = "ACDC.jpg" },
            new ArtistDto() { ArtistName = "NEFFEX", Image = "Neffex.jpg" }
        };

        public ObservableCollection<AlbumDto> Albums
        {
            get => albums;
        }

        public ObservableCollection<TrackDto> Tracks
        {
            get => tracks;
        }

        public ObservableCollection<ArtistDto> Artists
        {
            get => artists;
        }

        public HomeViewModel()
        {

        }
    }
}
