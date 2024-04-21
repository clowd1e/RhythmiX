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

        public static async Task<T?> GetObjectByIdAsync<T>(string catalogue, long id, string parameters = "")
        {
            using (HttpClient client = new HttpClient())
            {
                string requestUrl = $"{baseUrl}/{catalogue}/?client_id={clientId}{parameters}&format=jsonpretty&id={id}";
                HttpResponseMessage response = await client.GetAsync(requestUrl);
                if (response is null)
                    throw new HttpRequestException("Response is null");

                if (response.IsSuccessStatusCode)
                    return await ReadResponse<T>(response);
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
