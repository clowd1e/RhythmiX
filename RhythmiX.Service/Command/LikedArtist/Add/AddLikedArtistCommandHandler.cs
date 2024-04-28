using Cinema.Service;
using FluentValidation.Results;
using RhythmiX.Storage.Entities;
using RhythmiX.Storage.Repository;

namespace RhythmiX.Service.Command.LikedArtist.Add
{
    public class AddLikedArtistCommandHandler : ICommandHandler<AddLikedArtistCommand>
    {
        private readonly IMusicRepository _repository;

        public AddLikedArtistCommandHandler(IMusicRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result> HandleAsync(AddLikedArtistCommand command)
        {
            ValidationResult validationResult = new AddLikedArtistCommandValidator().Validate(command);

            if (!validationResult.IsValid)
                return Result.Fail(validationResult.ToString());

            bool isArtistLiked = _repository.IsArtistLiked(command.UserId, command.ArtistId).Result;
            if (isArtistLiked)
                return Result.Fail("This artist is already liked");

            Artist artist = new Artist(command.ArtistId, command.Name, command.JoinDate, command.Website, command.Image);

            await _repository.AddLikedArtistAsync(command.UserId, artist);

            return Result.Ok();
        }
    }
}
