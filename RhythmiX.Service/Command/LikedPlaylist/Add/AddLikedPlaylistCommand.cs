using Newtonsoft.Json;

namespace RhythmiX.Service.Command.LikedPlaylist.Add
{
    public class AddLikedPlaylistCommand : ICommand
    {
        public long UserId { get; set; }
        public long PlaylistId { get; set; }

        public string Name { get; set; }
        public DateOnly CreationDate { get; set; }
        public string ApiUserId { get; set; }
        public string ApiUserName { get; set; }
        public string Zip { get; set; }
    }
}
