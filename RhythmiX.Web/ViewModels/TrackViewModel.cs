using RhythmiX.Service.Queries.Dtos;
using RhythmiX.Storage.Entities;

namespace RhythmiX.Web.ViewModels
{
    public class TrackViewModel
    {
        public long UserId { get; set; }
        public long TrackId { get; set; }
        public string Title { get; set; }
        public IEnumerable<Track> Tracks { get; set; }
        public IEnumerable<TrackDto> TrackDtos { get; set; }
    }
}
