using RhythmiX.Service.Queries.Dtos;
using RhythmiX.Storage.Entities;
using RhythmiX.WPF.Services;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace RhythmiX.WPF.ViewModels
{
    public class MusicControlViewModel : ViewModelBase
    {
        private List<Track> _tracks;

        private ObservableCollection<TrackDto> trackDtos;
        public ObservableCollection<TrackDto> TrackDtos
        {
            get => trackDtos;
            set
            {
                trackDtos = value;
                OnPropertyChanged(nameof(TrackDtos));
            }
        }

        private bool isLoading;
        public bool IsLoading
        {
            get => isLoading;
            set
            {
                isLoading = value;
                OnPropertyChanged(nameof(IsLoading));
            }
        }

        private string title;
        public string Title
        {
            get => title;
            set
            {
                title = value;
                OnPropertyChanged(nameof(Title));
            }
        }

        private ImageSource currentImage;
        public ImageSource CurrentImage
        {
            get => currentImage;
            set
            {
                currentImage = value;
                OnPropertyChanged(nameof(CurrentImage));
            }
        }

        private int currentTrackId;
        public int CurrentTrackId
        {
            get => currentTrackId;
            set
            {
                currentTrackId = value;
                OnPropertyChanged(nameof(CurrentTrackId));
            }
        }

        public void UpdateTracks(List<Track> tracks)
        {
            _tracks = tracks;
            TrackDtos = new ObservableCollection<TrackDto>(_tracks.Select(track => new TrackDto(track)));
            CurrentImage = new BitmapImage(new Uri(Path.GetFullPath($"{PathService.DownloadedTracksPath}/{trackDtos[currentTrackId].TrackName}/{trackDtos[currentTrackId].Image}")));
        }
    }
}
