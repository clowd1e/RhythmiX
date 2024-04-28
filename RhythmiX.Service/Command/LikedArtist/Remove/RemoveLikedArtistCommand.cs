namespace RhythmiX.Service.Command.LikedArtist.Remove
{
    public class RemoveLikedArtistCommand : ICommand
    {
        public long UserId { get; set; }
        public long ArtistId { get; set; }
    }
}
