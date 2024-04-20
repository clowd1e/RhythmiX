using Newtonsoft.Json;
using RhythmiX.Service.API.ResponseModels;

namespace RhythmiX.Service.API
{
    public static class ApiHelper
    {
        private const string baseUrl = "https://api.jamendo.com/v3.0";

        private const string filePath = "../../../API/APIKey/ApiKey.json";
        private static string? clientId = JsonConvert.DeserializeObject<string>(
            new StreamReader(filePath).ReadToEnd()
            );

        public static async Task<TrackResponseModel?> GetTrackByIdAsync(long id)
        {
            using (HttpClient client = new HttpClient())
            {
                string requestUrl = $"{baseUrl}/tracks/?client_id={clientId}&format=jsonpretty&id={id}";
                HttpResponseMessage response = await client.GetAsync(requestUrl);

                if (response.IsSuccessStatusCode)
                    return await ReadResponse<TrackResponseModel>(response);
                else
                    throw new HttpRequestException(response.ReasonPhrase);
            }
        }

        private static async Task<T?> ReadResponse<T>(HttpResponseMessage response)
        {
            string responseBody = await response.Content.ReadAsStringAsync();
            T? responseModel = JsonConvert.DeserializeObject<T>(responseBody);
            return responseModel;
        }
    }
}
