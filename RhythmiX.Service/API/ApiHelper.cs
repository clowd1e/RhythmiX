using Newtonsoft.Json;
using RhythmiX.Service.API.ResponseModels;

namespace RhythmiX.Service.API
{
    public static class ApiHelper
    {
        private const string baseUrl = "https://api.jamendo.com/v3.0";

        private const string filePath = "../../../../RhythmiX.Service/API/APIKey/ApiKey.json";
        private static string? clientId = JsonConvert.DeserializeObject<string>(
            new StreamReader(filePath).ReadToEnd()
            );

        public static async Task<TResponseModel?> GetObjectByIdAsync<TResponseModel>(string catalogue, long id, string parameters = "")
            where TResponseModel : IResponseModel
        {
            using (HttpClient client = new HttpClient())
            {
                string requestUrl = $"{baseUrl}/{catalogue}/?client_id={clientId}{parameters}&format=jsonpretty&id={id}";
                HttpResponseMessage response = await client.GetAsync(requestUrl);
                if (response is null)
                    throw new HttpRequestException("Response is null");

                if (response.IsSuccessStatusCode)
                    return await ReadResponse<TResponseModel>(response);
                else
                    throw new HttpRequestException(response.ReasonPhrase);
            }
        }

        public static async Task<TResponseModel?> GetTracksByTags<TResponseModel>(string tags, string parameters = "")
            where TResponseModel : IResponseModel
        {
            using (HttpClient client = new HttpClient())
            {
                string requestUrl = $"{baseUrl}/tracks/?client_id={clientId}{parameters}&format=jsonpretty&tags={tags}";
                HttpResponseMessage response = await client.GetAsync(requestUrl);
                if (response is null)
                    throw new HttpRequestException("Response is null");

                if (response.IsSuccessStatusCode)
                    return await ReadResponse<TResponseModel>(response);
                else
                    throw new HttpRequestException(response.ReasonPhrase);
            }
        }

        private static async Task<TResponseModel?> ReadResponse<TResponseModel>(HttpResponseMessage response)
            where TResponseModel : IResponseModel
        {
            string responseBody = await response.Content.ReadAsStringAsync();
            TResponseModel? responseModel = JsonConvert.DeserializeObject<TResponseModel>(responseBody);
            return responseModel;
        }
    }
}
