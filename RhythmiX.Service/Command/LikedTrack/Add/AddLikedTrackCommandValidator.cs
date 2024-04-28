using FluentValidation;

namespace RhythmiX.Service.Command.LikedTrack.Add
{
    public class AddLikedTrackCommandValidator : AbstractValidator<AddLikedTrackCommand>
    {
        public AddLikedTrackCommandValidator()
        {
            RuleFor(x => x.UserId).NotEmpty();
            RuleFor(x => x.AlbumId).NotEmpty();
            RuleFor(x => x.ApiTrackId).NotEmpty();
            RuleFor(x => x.ArtistId).NotEmpty();
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Duration).NotEmpty();
            RuleFor(x => x.Duration).ExclusiveBetween(10, 600);
            RuleFor(x => x.ReleaseDate).NotEmpty();
            RuleFor(x => x.ReleaseDate).LessThanOrEqualTo(DateOnly.FromDateTime(DateTime.UtcNow));
            RuleFor(x => x.Image).NotEmpty();
            RuleFor(x => x.Audio).NotEmpty();
            RuleFor(x => x.AudioDownload).NotEmpty();
        }
    }
}
