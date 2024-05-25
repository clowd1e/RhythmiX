using RhythmiX.Service.API.ResponseModels.Interfaces;

namespace RhythmiX.Service.API.ResponseModels
{
    public abstract class ResponseModelBase : IResponseModel
    {
        public ResponseHeader Headers { get; set; }
    }
}
