using RhythmiX.Service.Downloaders.ImageDownloader;
using RhythmiX.Service.Queries.HistoryTrack;
using RhythmiX.Storage;
using RhythmiX.Storage.Entities;
using RhythmiX.Storage.Repository;
using RhythmiX.WPF.Services;
using RhythmiX.WPF.ViewModels.MenuViewModels;

namespace RhythmiX.WPF.Commands
{
    public class LoadHistoryContentCommand : AsyncCommandBase
    {
        private readonly HistoryViewModel _viewModel;
        private readonly User _user;

        public LoadHistoryContentCommand(HistoryViewModel viewModel, User user)
        {
            _viewModel = viewModel;
            _user = user;
        }

        public async override Task ExecuteAsync(object? parameter)
        {
            _viewModel.IsLoading = true;

            using MusicDbContext context = new MusicDbContext();
            MusicRepository repository = new MusicRepository(context);

            GetUserHistoryTracksQuery query = new GetUserHistoryTracksQuery();
            GetUserHistoryTracksQueryHandler handler = new GetUserHistoryTracksQueryHandler(repository, _user);

            IEnumerable<Track> historyTracks = await handler.HandleAsync(query);

            await ImageDownloader.DownloadImagesAsync(historyTracks, PathService.DownloadedTracksPath);

            _viewModel.UpdateContent(historyTracks);

            _viewModel.IsLoading = false;
        }
    }
}
