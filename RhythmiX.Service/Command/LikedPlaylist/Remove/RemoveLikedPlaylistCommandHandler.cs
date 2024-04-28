using Cinema.Service;
using RhythmiX.Storage.Repository;

namespace RhythmiX.Service.Command.LikedPlaylist.Remove
{
    public class RemoveLikedPlaylistCommandHandler : ICommandHandler<RemoveLikedPlaylistCommand>
    {
        private readonly IMusicRepository _repository;
        public RemoveLikedPlaylistCommandHandler(IMusicRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result> HandleAsync(RemoveLikedPlaylistCommand command)
        {
            bool isPlaylistLiked = await _repository.IsPlaylistLiked(command.UserId, command.PlaylistId);
            if (!isPlaylistLiked)
                return Result.Fail("Liked playlist not found.");

            await _repository.RemoveLikedPlaylistAsync(command.UserId, command.PlaylistId);

            return Result.Ok();
        }
    }
}
