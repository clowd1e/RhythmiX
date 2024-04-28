using Cinema.Service;
using RhythmiX.Storage.Repository;

namespace RhythmiX.Service.Command.LikedTrack.Remove
{
    public class RemoveLikedTrackHandler : ICommandHandler<RemoveLikedTrackCommand>
    {
        private readonly IMusicRepository _repository;

        public RemoveLikedTrackHandler(IMusicRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result> HandleAsync(RemoveLikedTrackCommand command)
        {
            bool isTrackLiked = await _repository.IsTrackLiked(command.UserId, command.TrackId);
            if (!isTrackLiked)
                return Result.Fail("Liked track not found.");

            await _repository.RemoveLikedTrackAsync(command.UserId, command.UserId);

            return Result.Ok();
        }
    }
}
