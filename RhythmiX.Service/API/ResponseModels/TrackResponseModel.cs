using RhythmiX.Service.API.Models;

namespace RhythmiX.Service.API.ResponseModels
{
    public class TrackResponseModel : ResponseModelBase
    {
        public List<TrackModel> Results { get; set; }
    }
}
