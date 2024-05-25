using RhythmiX.Service.API;
using RhythmiX.Service.API.Models.Interfaces;
using RhythmiX.Service.API.ResponseModels;
using RhythmiX.Service.Downloaders.ImageDownloader;
using RhythmiX.WPF.Services;
using RhythmiX.WPF.Stores;
using RhythmiX.WPF.ViewModels.MenuViewModels;

namespace RhythmiX.WPF.Commands
{
    public class LoadHomeContentCommand : AsyncCommandBase
    {
        private readonly HomeViewModel _viewModel;
        
        public LoadHomeContentCommand(HomeViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public async override Task ExecuteAsync(object? parameter)
        {
            _viewModel.IsLoading = true;

            List<MusicGroupStore<IHomeObservable>> content = new List<MusicGroupStore<IHomeObservable>>();

            TrackResponseModel response = await ApiHelper.GetTracksByTags<TrackResponseModel>("rock", "&limit=15");
            response.Results = response.Results.Where(r => r.AudioDownloadAllowed).ToList();
            content.Add(new MusicGroupStore<IHomeObservable>("Rock music", response.Results.Cast<IHomeObservable>().ToList()));

            TrackResponseModel response2 = await ApiHelper.GetTracksByTags<TrackResponseModel>("rap", "&limit=15");
            response2.Results = response2.Results.Where(r => r.AudioDownloadAllowed).ToList();
            content.Add(new MusicGroupStore<IHomeObservable>("Pop music", response2.Results.Cast<IHomeObservable>().ToList()));

            await ImageDownloader.DownloadImagesAsync(response, PathService.DownloadedTracksPath);
            await ImageDownloader.DownloadImagesAsync(response2, PathService.DownloadedTracksPath);

            _viewModel.UpdateContent(content);

            _viewModel.IsLoading = false;
        }
    }
}
