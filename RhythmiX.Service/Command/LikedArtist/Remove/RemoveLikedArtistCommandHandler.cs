using Cinema.Service;
using RhythmiX.Storage.Repository;

namespace RhythmiX.Service.Command.LikedArtist.Remove
{
    public class RemoveLikedArtistCommandHandler : ICommandHandler<RemoveLikedArtistCommand>
    {
        private readonly IMusicRepository _repository;

        public RemoveLikedArtistCommandHandler(IMusicRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result> HandleAsync(RemoveLikedArtistCommand command)
        {
            bool isArtistLiked = _repository.IsArtistLiked(command.UserId, command.ArtistId).Result;
            if (!isArtistLiked)
                return Result.Fail("Liked artist not found");

            await _repository.RemoveLikedArtistAsync(command.UserId, command.ArtistId);

            return Result.Ok();
        }
    }
}
