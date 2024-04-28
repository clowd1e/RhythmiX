using Newtonsoft.Json;

namespace RhythmiX.Service.Command.LikedAlbums.Add
{
    public class AddLikedAlbumCommand : ICommand
    {
        public long UserId { get; set; }
        public long ApiAlbumId { get; set; }

        public string Name { get; set; }
        public DateOnly ReleaseDate { get; set; }
        public long ArtistId { get; set; }
        public string ArtistName { get; set; }
        public string Image { get; set; }
        public string Zip { get; set; }
    }
}
