namespace RhythmiX.Service.API.ResponseModels
{
    public abstract class ResponseModelBase : IResponceModel
    {
        public ResponseHeader Headers { get; set; }
    }
}
