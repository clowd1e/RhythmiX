using Cinema.Service;
using FluentValidation.Results;
using RhythmiX.Storage.Entities;
using RhythmiX.Storage.Repository;

namespace RhythmiX.Service.Command.LikedPlaylist.Add
{
    public class AddLikedPlaylistCommandHandler : ICommandHandler<AddLikedPlaylistCommand>
    {
        private readonly IMusicRepository _repository;

        public AddLikedPlaylistCommandHandler(IMusicRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result> HandleAsync(AddLikedPlaylistCommand command)
        {
            ValidationResult validationResult = new AddLikedPlaylistCommandValidator().Validate(command);

            if (!validationResult.IsValid)
                return Result.Fail(validationResult);

            bool isAlbumLiked = _repository.IsPlaylistLiked(command.UserId, command.PlaylistId).Result;

            if (isAlbumLiked)
                return Result.Fail("This playlist is already liked");

            Playlist playlist = new Playlist(command.PlaylistId, command.Name, command.CreationDate, command.ApiUserId,
                command.ApiUserName, command.Zip);

            await _repository.AddLikedPlaylistAsync(command.UserId, playlist);

            return Result.Ok();
        }
    }
}
