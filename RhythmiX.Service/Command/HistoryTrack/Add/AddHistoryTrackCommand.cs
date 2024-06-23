using RhythmiX.Storage.Entities;

namespace RhythmiX.Service.Command.HistoryTrack.Add
{
    public class AddHistoryTrackCommand : ICommand
    {
        public long UserId { get; set; }
        public Track Track { get; set; }
        public AddHistoryTrackCommand(long userId, Track track)
        {
            UserId = userId;
            Track = track;
        }
    }
}
