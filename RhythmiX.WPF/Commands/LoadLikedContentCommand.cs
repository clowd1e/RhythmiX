using RhythmiX.Service.Downloaders.ImageDownloader;
using RhythmiX.Service.Queries.LikedTrack;
using RhythmiX.Storage;
using RhythmiX.Storage.Entities;
using RhythmiX.Storage.Repository;
using RhythmiX.WPF.Services;
using RhythmiX.WPF.ViewModels.MenuViewModels;

namespace RhythmiX.WPF.Commands
{
    public class LoadLikedContentCommand : AsyncCommandBase
    {
        private readonly LikedViewModel _viewModel;
        private readonly User _user;

        public LoadLikedContentCommand(LikedViewModel viewModel, User user)
        {
            _viewModel = viewModel;
            _user = user;
        }

        public async override Task ExecuteAsync(object? parameter)
        {
            _viewModel.IsLoading = true;

            using MusicDbContext context = new MusicDbContext();
            MusicRepository repository = new MusicRepository(context);

            GetUserLikedTracksQuery query = new GetUserLikedTracksQuery();
            GetUserLikedTracksQueryHandler handler = new GetUserLikedTracksQueryHandler(repository, _user);

            IEnumerable<Track> likedTracks = await handler.HandleAsync(query);

            await ImageDownloader.DownloadImagesAsync(likedTracks, PathService.DownloadedTracksPath);

            _viewModel.UpdateContent(likedTracks);

            _viewModel.IsLoading = false;
        }
    }
}
