namespace RhythmiX.Service.Command.LikedAlbums.Remove
{
    public class RemoveLikedAlbumCommand : ICommand
    {
        public long UserId { get; set; }
        public long AlbumId { get; set; }
    }
}
