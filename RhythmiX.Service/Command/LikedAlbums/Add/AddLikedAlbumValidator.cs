using FluentValidation;

namespace RhythmiX.Service.Command.LikedAlbums.Add
{
    public class AddLikedAlbumValidator : AbstractValidator<AddLikedAlbumCommand>
    {
        public AddLikedAlbumValidator()
        {
            RuleFor(x => x.UserId).NotEmpty();
            RuleFor(x => x.ApiAlbumId).NotEmpty();
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.ReleaseDate).NotEmpty();
            RuleFor(x => x.ReleaseDate).LessThanOrEqualTo(DateOnly.FromDateTime(DateTime.UtcNow));
            RuleFor(x => x.ArtistId).NotEmpty();
            RuleFor(x => x.ArtistName).NotEmpty();
            RuleFor(x => x.Image).NotEmpty();
            RuleFor(x => x.Zip).NotEmpty();
        }
    }
}
