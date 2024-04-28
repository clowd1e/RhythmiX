namespace RhythmiX.Service.Command.LikedTrack.Remove
{
    public class RemoveLikedTrackCommand : ICommand
    {
        public long UserId { get; set; }
        public long TrackId { get; set; }
    }
}
