using FluentValidation;

namespace RhythmiX.Service.Command.LikedPlaylist.Add
{
    public class AddLikedPlaylistCommandValidator : AbstractValidator<AddLikedPlaylistCommand>
    {
        public AddLikedPlaylistCommandValidator()
        {
            RuleFor(x => x.UserId).NotEmpty();
            RuleFor(x => x.PlaylistId).NotEmpty();
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.CreationDate).NotEmpty();
            RuleFor(x => x.CreationDate).LessThanOrEqualTo(DateOnly.FromDateTime(DateTime.UtcNow));
            RuleFor(x => x.ApiUserId).NotEmpty();
            RuleFor(x => x.ApiUserName).NotEmpty();
            RuleFor(x => x.Zip).NotEmpty();
        }
    }
}
