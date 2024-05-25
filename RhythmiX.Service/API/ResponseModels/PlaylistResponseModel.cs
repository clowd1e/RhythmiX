using RhythmiX.Service.API.Models;

namespace RhythmiX.Service.API.ResponseModels
{
    public class PlaylistResponseModel : ResponseModelBase
    {
        public List<PlaylistModel> Results { get; set; }
    }
}
