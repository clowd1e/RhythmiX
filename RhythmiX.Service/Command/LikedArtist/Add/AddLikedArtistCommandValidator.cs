using FluentValidation;

namespace RhythmiX.Service.Command.LikedArtist.Add
{
    public class AddLikedArtistCommandValidator : AbstractValidator<AddLikedArtistCommand>
    {
        public AddLikedArtistCommandValidator()
        {
            RuleFor(x => x.UserId).NotEmpty();
            RuleFor(x => x.ArtistId).NotEmpty();
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.JoinDate).NotEmpty();
            RuleFor(x => x.JoinDate).LessThanOrEqualTo(DateOnly.FromDateTime(DateTime.UtcNow));
            RuleFor(x => x.Image).NotEmpty();
        }
    }
}
