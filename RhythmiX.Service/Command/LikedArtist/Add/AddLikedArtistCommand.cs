namespace RhythmiX.Service.Command.LikedArtist.Add
{
    public class AddLikedArtistCommand : ICommand
    {
        public long UserId { get; set; }
        public long ArtistId { get; set; }

        public string Name { get; set; }
        public DateOnly JoinDate { get; set; }
        public string Website { get; set; }
        public string Image { get; set; }
    }
}
