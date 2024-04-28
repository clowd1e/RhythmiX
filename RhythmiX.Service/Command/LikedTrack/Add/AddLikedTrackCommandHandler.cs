using Cinema.Service;
using RhythmiX.Storage.Repository;
using FluentValidation.Results;
using RhythmiX.Storage.Entities;

namespace RhythmiX.Service.Command.LikedTrack.Add
{
    public class AddLikedTrackCommandHandler : ICommandHandler<AddLikedTrackCommand>
    {
        private readonly IMusicRepository _repository;

        public AddLikedTrackCommandHandler(IMusicRepository repository)
        {
            _repository = repository;
        }
        public async Task<Result> HandleAsync(AddLikedTrackCommand command)
        {
            ValidationResult validationResult = new AddLikedTrackCommandValidator().Validate(command);

            if (!validationResult.IsValid)
                return Result.Fail(validationResult);

            bool isTrackLiked = _repository.IsTrackLiked(command.UserId, command.ApiTrackId).Result;

            if (isTrackLiked)
                return Result.Fail("This track is already liked");

            Track track = new Track(command.ApiTrackId, command.AlbumId, command.AlbumName, command.ArtistId, command.Name,
                command.Duration, command.ReleaseDate, command.AlbumImage, command.Image, command.Audio, command.AudioDownload);

            await _repository.AddLikedTrackAsync(command.UserId, track);

            return Result.Ok();
        }
    }
}
