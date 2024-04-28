namespace RhythmiX.Service.Command.LikedPlaylist.Remove
{
    public class RemoveLikedPlaylistCommand : ICommand
    {
        public long UserId { get; set; }
        public long PlaylistId { get; set; }
    }
}
