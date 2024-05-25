namespace RhythmiX.Service.Command.LikedTrack.Add
{
    public class AddLikedTrackCommand : ICommand
    {
        public long UserId { get; set; }
        public long ApiTrackId { get; set; }

        public long AlbumId { get; set; }
        public string AlbumName { get; set; }
        public long ArtistId { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }
        public DateOnly ReleaseDate { get; set; }
        public string AlbumImage { get; set; }
        public string Image { get; set; }
        public string Audio { get; set; }
        public string AudioDownload { get; set; }
    }
}
