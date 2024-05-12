using RhythmiX.Service.API.ResponseModels;
using System.IO.Compression;
using System.Net;

namespace RhythmiX.Service.Downloaders.ZipDownloader
{
    public static class ZipDownloader
    {
        public static async Task DownloadAlbumAsync(AlbumResponseModel response, string folderPath)
        {
            string name = response.Results[0].Name;
            string zipPath = response.Results[0].Zip;
            string imagePath = response.Results[0].Image;

            Directory.CreateDirectory($"{folderPath}/{name}");
            Uri url = new Uri(zipPath);
            string zipSavePath = $"{folderPath}/{name}/{name}.zip";

            if (File.Exists($"{folderPath}/{name}"))
                return;

            using (WebClient client = new WebClient())
            {
                await client.DownloadFileTaskAsync(url, zipSavePath);
                await ImageDownloader.ImageDownloader.DownloadImageAsync(name, imagePath, folderPath);
            }

            ZipFile.ExtractToDirectory(zipSavePath, $"{folderPath}/{name}");
            File.Delete(zipSavePath);
        }

        public static async Task DownloadPlaylistAsync(PlaylistResponseModel response, string folderPath)
        {
            string name = response.Results[0].Name;
            string zipPath = response.Results[0].Zip;

            Directory.CreateDirectory($"{folderPath}/{name}");
            Uri url = new Uri(zipPath);
            string zipSavePath = $"{folderPath}/{name}/{name}.zip";

            if (File.Exists($"{folderPath}/{name}"))
                return;

            using (WebClient client = new WebClient())
            {
                await client.DownloadFileTaskAsync(url, zipSavePath);
            }

            ZipFile.ExtractToDirectory(zipSavePath, $"{folderPath}/{name}");
            File.Delete(zipSavePath);
        }
    }
}
