using Cinema.Service;
using FluentValidation.Results;
using RhythmiX.Storage.Entities;
using RhythmiX.Storage.Repository;

namespace RhythmiX.Service.Command.LikedAlbum.Add
{
    public class AddLikedAlbumCommandHandler : ICommandHandler<AddLikedAlbumCommand>
    {
        private readonly IMusicRepository _repository;

        public AddLikedAlbumCommandHandler(IMusicRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result> HandleAsync(AddLikedAlbumCommand command)
        {
            ValidationResult validationResult = new AddLikedAlbumCommandValidator().Validate(command);

            if (!validationResult.IsValid)
                return Result.Fail(validationResult);

            bool isAlbumLiked = _repository.IsAlbumLiked(command.UserId, command.ApiAlbumId).Result;

            if (isAlbumLiked)
                return Result.Fail("This album is already liked");

            Album album = new Album(command.ApiAlbumId, command.Name, command.ReleaseDate, command.ArtistId, 
                command.ArtistName, command.Image, command.Zip);

            await _repository.AddLikedAlbumAsync(command.UserId, album);

            return Result.Ok();
        }
    }
}
