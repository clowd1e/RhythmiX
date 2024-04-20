namespace RhythmiX.Service.API.ResponseModels
{
    public class ResponseHeader
    {
        public string Status { get; set; }
        public int Code { get; set; }
        public string? ErrorMessage { get; set; }
        public string? Warnings { get; set; }
        public int ResultsCount { get; set; }
    }
}
