using Cinema.Service;
using RhythmiX.Storage.Repository;

namespace RhythmiX.Service.Command.LikedAlbums.Remove
{
    public class RemoveLikedAlbumCommandHandler : ICommandHandler<RemoveLikedAlbumCommand>
    {
        private readonly IMusicRepository _repository;
        public RemoveLikedAlbumCommandHandler(IMusicRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result> HandleAsync(RemoveLikedAlbumCommand command)
        {
            bool isAlbumLiked = await _repository.IsAlbumLiked(command.UserId, command.AlbumId);
            if (!isAlbumLiked)
                return Result.Fail("Liked album not found.");

            await _repository.RemoveLikedAlbumAsync(command.UserId, command.AlbumId);

            return Result.Ok();
        }
    }
}
