using RhythmiX.Service.API.Models;

namespace RhythmiX.Service.API.ResponseModels
{
    public class AlbumResponseModel : ResponseModelBase
    {
        public List<AlbumModel> Results { get; set; } 
    }
}
