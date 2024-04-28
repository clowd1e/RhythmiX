namespace RhythmiX.Service.Command.LikedAlbum.Remove
{
    public class RemoveLikedAlbumCommand : ICommand
    {
        public long UserId { get; set; }
        public long AlbumId { get; set; }
    }
}
