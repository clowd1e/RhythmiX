﻿using Newtonsoft.Json;
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

        public static async Task<TResponceModel?> GetObjectByIdAsync<TResponceModel>(string catalogue, long id, string parameters = "")
            where TResponceModel : IResponceModel
        {
            using (HttpClient client = new HttpClient())
            {
                string requestUrl = $"{baseUrl}/{catalogue}/?client_id={clientId}{parameters}&format=jsonpretty&id={id}";
                HttpResponseMessage response = await client.GetAsync(requestUrl);
                if (response is null)
                    throw new HttpRequestException("Response is null");

                if (response.IsSuccessStatusCode)
                    return await ReadResponse<TResponceModel>(response);
                else
                    throw new HttpRequestException(response.ReasonPhrase);
            }
        }

        private static async Task<TResponceModel?> ReadResponse<TResponceModel>(HttpResponseMessage response)
            where TResponceModel : IResponceModel
        {
            string responseBody = await response.Content.ReadAsStringAsync();
            TResponceModel? responseModel = JsonConvert.DeserializeObject<TResponceModel>(responseBody);
            return responseModel;
        }
    }
}
