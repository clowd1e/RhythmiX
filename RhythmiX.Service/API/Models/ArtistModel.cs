using RhythmiX.Service.API.Models.Interfaces;

namespace RhythmiX.Service.API.Models
{
    public class ArtistModel : IHomeObservable, IHistoryObservable
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateOnly JoinDate { get; set; }
        public string Website { get; set; }
        public string Image { get; set; }
    }
}
