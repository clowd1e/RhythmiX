using RhythmiX.Service.API.ResponseModels;
using RhythmiX.Storage.Entities;
using System.Net;

namespace RhythmiX.Service.Downloaders.ImageDownloader
{
    public static class ImageDownloader
    {
        private static readonly string imageFormat = ".jpg";

        public static async Task DownloadImageAsync(string name, string imagePath, string folderPath)
        {
            Uri url = new Uri(imagePath);
            Directory.CreateDirectory($"{folderPath}/{name}");
            folderPath = $"{folderPath}/{name}/{name}{imageFormat}";

            if (File.Exists(folderPath))
                return;

            using (WebClient client = new WebClient())
            {
                await client.DownloadFileTaskAsync(url, folderPath);
            }
        }

        public static async Task DownloadImagesAsync(TrackResponseModel response, string folderPath)
        {
            foreach (var track in response.Results)
            {
                string name = track.Name;
                string imagePath = track.Image;

                await DownloadImageAsync(name, imagePath, folderPath);
            }
        }
        public static async Task DownloadImagesAsync(IEnumerable<Track> tracks, string folderPath)
        {
            foreach (var track in tracks)
            {
                string name = track.Name;
                string imagePath = track.Image;

                await DownloadImageAsync(name, imagePath, folderPath);
            }
        }
    }
}
