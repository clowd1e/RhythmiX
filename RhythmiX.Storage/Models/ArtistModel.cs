namespace RhythmiX.Storage.Models
{
    public class ArtistModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateOnly JoinDate { get; set; }
        public string Website { get; set; }
        public string Image { get; set; }
    }
}
