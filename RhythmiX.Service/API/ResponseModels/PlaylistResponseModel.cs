using RhythmiX.Storage.Models;

namespace RhythmiX.Service.API.ResponseModels
{
    public class PlaylistResponseModel : ResponseModelBase
    {
        public List<PlaylistModel> Results { get; set; }
    }
}
