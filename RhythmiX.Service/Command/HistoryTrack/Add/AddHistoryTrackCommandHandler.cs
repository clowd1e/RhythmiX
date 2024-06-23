using Cinema.Service;
using RhythmiX.Storage.Repository;

namespace RhythmiX.Service.Command.HistoryTrack.Add
{
    public class AddHistoryTrackCommandHandler : ICommandHandler<AddHistoryTrackCommand>
    {
        private readonly IMusicRepository _repository;
        public AddHistoryTrackCommandHandler(IMusicRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result> HandleAsync(AddHistoryTrackCommand command)
        {
            await _repository.AddTrackToHistoryAsync(command.UserId, command.Track);

            return Result.Ok();
        }
    }
}
