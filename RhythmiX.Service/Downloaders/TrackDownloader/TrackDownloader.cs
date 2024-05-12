using RhythmiX.Service.API.ResponseModels;
using System.Net;

namespace RhythmiX.Service.Downloaders.TrackDownloader
{
    public static class TrackDownloader
    {
        private static readonly string audioFormat = ".mp3";
        public static async Task DownloadTrackAsync(TrackResponseModel response, string folderPath)
        {
            string name = response.Results[0].Name;
            string audioPath = response.Results[0].AudioDownload;
            string imagePath = response.Results[0].AlbumImage;

            Directory.CreateDirectory($"{folderPath}/{name}");
            Uri url = new Uri(audioPath);
            string trackSavePath = $"{folderPath}/{name}/{name}{audioFormat}";

            if (File.Exists($"{folderPath}/{name}/{name}{audioFormat}"))
                return;

            using (WebClient client = new WebClient())
            {
                await client.DownloadFileTaskAsync(url, trackSavePath);
                await ImageDownloader.ImageDownloader.DownloadImageAsync(name, imagePath, folderPath);
            }
        }

        public static async Task DownloadTracksAsync(TrackResponseModel response, string folderPath)
        {
            foreach (var track in response.Results)
            {
                string name = track.Name;
                string audioPath = track.AudioDownload;
                string imagePath = track.AlbumImage;

                Directory.CreateDirectory($"{folderPath}/{name}");
                Uri url = new Uri(audioPath);
                string trackSavePath = $"{folderPath}/{name}/{name}{audioFormat}";

                if (File.Exists($"{folderPath}/{name}/{name}{audioFormat}"))
                    continue;

                using (WebClient client = new WebClient())
                {
                    await client.DownloadFileTaskAsync(url, trackSavePath);
                    await ImageDownloader.ImageDownloader.DownloadImageAsync(name, imagePath, folderPath);
                }
            }
        }
    }
}
