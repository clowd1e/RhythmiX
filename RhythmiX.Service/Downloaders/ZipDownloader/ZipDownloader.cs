using System.IO.Compression;
using System.Net;

namespace RhythmiX.Service.Downloaders.ZipDownloader
{
    public static class ZipDownloader
    {
        public static async Task DownloadZipAsync(string name, string zipPath, string imagePath, string folderPath)
        {
            Directory.CreateDirectory($"{folderPath}/{name}");
            Uri url = new Uri(zipPath);
            string zipSavePath = $"{folderPath}/{name}/{name}.zip";

            if (File.Exists(folderPath))
                return;

            using (WebClient client = new WebClient())
            {
                await client.DownloadFileTaskAsync(url, zipSavePath);
                await ImageDownloader.ImageDownloader.DownoladImageAsync(name, imagePath, folderPath);
            }

            ZipFile.ExtractToDirectory(zipSavePath, folderPath);
            File.Delete(zipSavePath);
        }
    }
}
