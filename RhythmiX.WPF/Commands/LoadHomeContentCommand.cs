using RhythmiX.Service.API;
using RhythmiX.Service.API.ResponseModels;
using RhythmiX.Service.Downloaders.ImageDownloader;
using RhythmiX.Storage.Models.Interfaces;
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
            TrackResponseModel response = await ApiHelper.GetTracksByTags<TrackResponseModel>("rock");
            response.Results = response.Results.Where(r => r.AudioDownloadAllowed).ToList();

            await ImageDownloader.DownloadImagesAsync(response, "../../../APICallResults/DownloadedMusic");
            _viewModel.UpdateContent(response.Results.Cast<IHomeObservable>().ToList());
        }
    }
}
