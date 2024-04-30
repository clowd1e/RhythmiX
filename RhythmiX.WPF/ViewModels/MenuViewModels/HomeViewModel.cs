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

        public ObservableCollection<AlbumDto> Albums
        {
            get => albums;
        }

        public HomeViewModel()
        {

        }
    }
}
