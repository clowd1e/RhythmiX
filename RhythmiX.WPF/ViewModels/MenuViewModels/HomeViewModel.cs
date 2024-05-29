using RhythmiX.Service.API.Models;
using RhythmiX.Service.API.Models.Interfaces;
using RhythmiX.Service.Queries.Dtos;
using RhythmiX.WPF.Commands;
using RhythmiX.WPF.Stores;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace RhythmiX.WPF.ViewModels.MenuViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        private List<MusicGroupStore<IHomeObservable>> _content;


        private List<MusicGroupStore<TrackModel>> tracks;
        private List<MusicGroupStore<AlbumModel>> albums;
        private List<MusicGroupStore<ArtistModel>> artists;
        private List<MusicGroupStore<PlaylistModel>> playlists;


        private ObservableCollection<MusicGroupStore<TrackDto>> trackDtos;
        public ObservableCollection<MusicGroupStore<TrackDto>> TrackDtos
        {
            get => trackDtos;
            set
            {
                trackDtos = value;
                OnPropertyChanged(nameof(trackDtos));
            }
        }

        private ObservableCollection<MusicGroupStore<AlbumDto>> albumDtos;
        public ObservableCollection<MusicGroupStore<AlbumDto>> AlbumDtos
        {
            get => albumDtos;
            set
            {
                albumDtos = value;
                OnPropertyChanged(nameof(albumDtos));
            }
        }

        private ObservableCollection<MusicGroupStore<ArtistDto>> artistDtos;
        public ObservableCollection<MusicGroupStore<ArtistDto>> ArtistDtos
        {
            get => artistDtos;
            set
            {
                artistDtos = value;
                OnPropertyChanged(nameof(artistDtos));
            }
        }

        private ObservableCollection<MusicGroupStore<PlaylistDto>> playlistDtos;
        public ObservableCollection<MusicGroupStore<PlaylistDto>> PlaylistDtos
        {
            get => playlistDtos;
            set
            {
                playlistDtos = value;
                OnPropertyChanged(nameof(playlistDtos));
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

        public ICommand LoadContentCommand { get; }

        public HomeViewModel()
        {
            //LoadContentCommand = new LoadHomeContentCommand(this);
            //LoadContentCommand.Execute(null);
        }

        public void UpdateContent(List<MusicGroupStore<IHomeObservable>> content)
        {
            _content = content;
            tracks = _content.Select(group => new MusicGroupStore<TrackModel>(
                    group.Title, group.Items.OfType<TrackModel>().ToList()
                    )).Where(group => group.Items.Any()).ToList();
            albums = _content.Select(group => new MusicGroupStore<AlbumModel>(
                    group.Title, group.Items.OfType<AlbumModel>().ToList()
                    )).Where(group => group.Items.Any()).ToList();
            artists = _content.Select(group => new MusicGroupStore<ArtistModel>(
                    group.Title, group.Items.OfType<ArtistModel>().ToList()
                    )).Where(group => group.Items.Any()).ToList();

            playlists = _content.Select(group => new MusicGroupStore<PlaylistModel>(
                    group.Title, group.Items.OfType<PlaylistModel>().ToList()
                    )).Where(group => group.Items.Any()).ToList();

            TrackDtos = new ObservableCollection<MusicGroupStore<TrackDto>>(
                tracks.Select(group => new MusicGroupStore<TrackDto>(group.Title, new ObservableCollection<TrackDto>(group.Items
                .Select(item => new TrackDto(item)))
                )));

            AlbumDtos = new ObservableCollection<MusicGroupStore<AlbumDto>>(
                albums.Select(group => new MusicGroupStore<AlbumDto>(group.Title, new ObservableCollection<AlbumDto>(group.Items
                .Select(item => new AlbumDto(item)))
                )));

            ArtistDtos = new ObservableCollection<MusicGroupStore<ArtistDto>>(
                artists.Select(group => new MusicGroupStore<ArtistDto>(group.Title, new ObservableCollection<ArtistDto>(group.Items
                .Select(item => new ArtistDto(item)))
                )));

            PlaylistDtos = new ObservableCollection<MusicGroupStore<PlaylistDto>>(
                playlists.Select(group => new MusicGroupStore<PlaylistDto>(group.Title, new ObservableCollection<PlaylistDto>(group.Items
                .Select(item => new PlaylistDto(item)))
                )));
        }
    }
}
