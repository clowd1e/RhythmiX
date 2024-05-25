using RhythmiX.Service.API.Models;

namespace RhythmiX.Service.API.ResponseModels
{
    public class ArtistResponseModel : ResponseModelBase
    {
        public List<ArtistModel> Results { get; set; }
    }
}
