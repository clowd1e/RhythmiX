using RhythmiX.Service.Downloaders.TrackDownloader;
using RhythmiX.Storage.Entities;
using RhythmiX.WPF.Services;
using RhythmiX.WPF.Stores;
using RhythmiX.WPF.ViewModels;

namespace RhythmiX.WPF.Commands
{
    public class AsyncLoadMusicCommand : AsyncCommandBase
    {
        private readonly MainWindowModel _mainWindowModel;
        private readonly NavigationStore _navigationStore;
        private readonly List<Track> _tracks;

        public AsyncLoadMusicCommand(MainWindowModel mainWindowModel, NavigationStore navigationStore, List<Track> tracks)
        {
            _mainWindowModel = mainWindowModel;
            _tracks = tracks;
            _navigationStore = navigationStore;
        }

        public async override Task ExecuteAsync(object? parameter)
        {
            if (parameter is null)
                return;

            int id = (int)parameter;

            MusicControlViewModel musicControl = new MusicControlViewModel();
            _navigationStore.CurrentViewModel = musicControl;

            musicControl.IsLoading = true;

            await DownloadMusicFiles();
            musicControl.CurrentTrackId = id;
            musicControl.UpdateTracks(_tracks);

            musicControl.IsLoading = false;
            _mainWindowModel.IsPlayerBarShown = true;
        }

        private async Task DownloadMusicFiles()
        {
            await TrackDownloader.DownloadTracksAsync(_tracks, PathService.DownloadedTracksPath);
        }
    }
}
