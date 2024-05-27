using RhythmiX.Service.Downloaders.TrackDownloader;
using RhythmiX.Storage.Entities;
using RhythmiX.WPF.Services;
using RhythmiX.WPF.Stores;
using RhythmiX.WPF.ViewModels;

namespace RhythmiX.WPF.Commands
{
    public class AsyncLoadMusicCommand : AsyncCommandBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly List<Track> _tracks;

        public AsyncLoadMusicCommand(NavigationStore navigationStore, List<Track> tracks)
        {
            _tracks = tracks;
            _navigationStore = navigationStore;
        }

        public async override Task ExecuteAsync(object? parameter)
        {
            MusicControlViewModel musicControl = new MusicControlViewModel();
            _navigationStore.CurrentViewModel = musicControl;

            musicControl.IsLoading = true;

            await DownloadMusicFiles();

            musicControl.IsLoading = false;
        }

        private async Task DownloadMusicFiles()
        {
            await TrackDownloader.DownloadTracksAsync(_tracks, PathService.DownloadedTracksPath);
        }
    }
}
