using RhythmiX.Storage.Models;

namespace RhythmiX.Service.API.ResponseModels
{
    public class ArtistResponseModel : ResponseModelBase
    {
        public List<ArtistModel> Results { get; set; }
    }
}
