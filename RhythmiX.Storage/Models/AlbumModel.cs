namespace RhythmiX.Storage.Models
{
    public class AlbumModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateOnly ReleaseDate { get; set; }
        public string ArtistId { get; set; }
        public string ArtistName { get; set; }
        public string Image { get; set; }
        public string Zip { get; set; }
    }
}
