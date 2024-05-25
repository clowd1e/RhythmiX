using RhythmiX.Service.Queries.Dtos;
using RhythmiX.Storage.Entities;
using RhythmiX.WPF.Commands;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace RhythmiX.WPF.ViewModels.MenuViewModels
{
    public class LikedViewModel : ViewModelBase
    {
        private List<Track> _likedTracks;

        private int count;

        private string countText;
        public string CountText
        {
            get => countText;
            set
            {
                countText = value;
                OnPropertyChanged(nameof(CountText));
            }
        }

        private bool hasTracks;
        public bool HasTracks
        {
            get => hasTracks;
            set
            {
                hasTracks = value;
                OnPropertyChanged(nameof(HasTracks));
            }
        }

        private ObservableCollection<TrackDto> likedTrackDtos;
        public ObservableCollection<TrackDto> LikedTrackDtos
        {
            get => likedTrackDtos;
            set
            {
                likedTrackDtos = value;
                OnPropertyChanged(nameof(LikedTrackDtos));
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

        public ICommand LoadContent;
        public LikedViewModel(User user)
        {
            LoadContent = new LoadLikedContentCommand(this, user);
            LoadContent.Execute(null);
        }

        public void UpdateContent(IEnumerable<Track> likedTracks)
        {
            _likedTracks = likedTracks.ToList();

            count = likedTracks.ToList().Count;
            HasTracks = count > 0;
            CountText = $"{count} {(count == 1 ? "song" : "songs")}";
            LikedTrackDtos = new ObservableCollection<TrackDto>(likedTracks.Select(t => new TrackDto(t)));
        }
    }
}
