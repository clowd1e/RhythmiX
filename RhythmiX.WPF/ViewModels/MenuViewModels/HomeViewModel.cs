using RhythmiX.Service.Queries.Dtos;
using RhythmiX.Storage.Models;
using RhythmiX.Storage.Models.Interfaces;
using RhythmiX.WPF.Commands;
using RhythmiX.WPF.Stores;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace RhythmiX.WPF.ViewModels.MenuViewModels
{
    public class HomeViewModel : ViewModelBase
    {

        private List<IHomeObservable> _content;

        private List<TrackModel> tracks;
        private ObservableCollection<TrackDto> trackDtos;
        public ObservableCollection<TrackDto> TrackDtos
        {
            get => trackDtos;
            set
            {
                trackDtos = value;
                OnPropertyChanged(nameof(trackDtos));
            }
        }

        public ICommand LoadContentCommand { get; }


        public HomeViewModel()
        {
            LoadContentCommand = new LoadHomeContentCommand(this);
            LoadContentCommand.Execute(null);
        }

        public void UpdateContent(List<IHomeObservable> content)
        {
            _content = content;
            tracks = _content.OfType<TrackModel>().ToList();
            TrackDtos = new ObservableCollection<TrackDto>(tracks.Select(t => new TrackDto(t)).Take(9));
        }

        //private ObservableCollection<AlbumDto> albums = new ObservableCollection<AlbumDto>() { 
        //    new AlbumDto() { AlbumName = "Album 1", ArtistName = "Artist 1", Image = "album_image_default.jpg" },
        //    new AlbumDto() { AlbumName = "Album 2", ArtistName = "Artist 2", Image = "album_image_default.jpg" },
        //    new AlbumDto() { AlbumName = "Album 3", ArtistName = "Artist 3", Image = "album_image_default.jpg" },
        //    new AlbumDto() { AlbumName = "Album 4", ArtistName = "Artist 4", Image = "album_image_default.jpg" }
        //};

        //private ObservableCollection<TrackDto> tracks = new ObservableCollection<TrackDto>()
        //{
        //    new TrackDto() { TrackName = "Track 1", ArtistName = "Artist 1", Image = "track_image_default.jpg" },
        //    new TrackDto() { TrackName = "Track 2", ArtistName = "Artist 2", Image = "track_image_default.jpg" },
        //    new TrackDto() { TrackName = "Track 3", ArtistName = "Artist 3", Image = "track_image_default.jpg" },
        //    new TrackDto() { TrackName = "Really cool song", ArtistName = "NIRVANA", Image = "Nirvana.jpg" },
        //    new TrackDto() { TrackName = "Track 5", ArtistName = "Artist 5", Image = "track_image_default.jpg" },
        //    new TrackDto() { TrackName = "Track 6", ArtistName = "Artist 6", Image = "track_image_default.jpg" },
        //    new TrackDto() { TrackName = "I need really long song name", ArtistName = "Long group name so that it's really long", Image = "NWA.jpg" },
        //    new TrackDto() { TrackName = "Track 8", ArtistName = "Artist 8", Image = "track_image_default.jpg" },
        //    new TrackDto() { TrackName = "Track 9", ArtistName = "Artist 9", Image = "track_image_default.jpg" }
        //};

        //private ObservableCollection<ArtistDto> artists = new ObservableCollection<ArtistDto>()
        //{
        //    new ArtistDto() { ArtistName = "NEFFEX", Image = "Neffex.jpg" },
        //    new ArtistDto() { ArtistName = "Metallica", Image = "Metallica.jpg" },
        //    new ArtistDto() { ArtistName = "AC/DC", Image = "ACDC.jpg" },
        //    new ArtistDto() { ArtistName = "NEFFEX", Image = "Neffex.jpg" }
        //};

        //private ObservableCollection<PlaylistDto> playlists = new ObservableCollection<PlaylistDto>()
        //{
        //    new PlaylistDto() { PlaylistName = "Playlist 1", ArtistName = "User 1", Image = "playlist_image_default.png" },
        //    new PlaylistDto() { PlaylistName = "Playlist 2", ArtistName = "Some other user", Image = "playlist_image_default.png" },
        //    new PlaylistDto() { PlaylistName = "Playlist 3", ArtistName = "Probably me", Image = "playlist_image_default.png" },
        //    new PlaylistDto() { PlaylistName = "Playlist 4", ArtistName = "YEAH", Image = "playlist_image_default.png" }
        //};


        //public ObservableCollection<AlbumDto> Albums
        //{
        //    get => albums;
        //}

        //public ObservableCollection<TrackDto> Tracks
        //{
        //    get => tracks;
        //}

        //public ObservableCollection<ArtistDto> Artists
        //{
        //    get => artists;
        //}

        //public ObservableCollection<PlaylistDto> Playlists
        //{
        //    get => playlists;
        //}
    }
}
