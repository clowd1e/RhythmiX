using RhythmiX.Service.API.ResponseModels;
using System.Net;

namespace RhythmiX.Service.Downloaders.TrackDownloader
{
    public static class TrackDownloader
    {
        public static async Task DownloadTrackAsync(TrackResponseModel response, string folderPath)
        {
            string name = response.Results[0].Name;
            string audioPath = response.Results[0].AudioDownload;
            string imagePath = response.Results[0].AlbumImage;

            Directory.CreateDirectory($"{folderPath}/{name}");
            Uri url = new Uri(audioPath);
            string trackSavePath = $"{folderPath}/{name}/{name}.mp3";

            if (File.Exists(folderPath))
                return;

            using (WebClient client = new WebClient())
            {
                await client.DownloadFileTaskAsync(url, trackSavePath);
                await ImageDownloader.ImageDownloader.DownoladImageAsync(name, imagePath, folderPath);
            }
        }
    }
}
