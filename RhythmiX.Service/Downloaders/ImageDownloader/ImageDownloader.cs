using System.Net;

namespace RhythmiX.Service.Downloaders.ImageDownloader
{
    public static class ImageDownloader
    {
        public static async Task DownoladImageAsync(string name, string imagePath, string folderPath)
        {
            Uri url = new Uri(imagePath);
            folderPath = $"{folderPath}/{name}/{name}.jpg";

            if (File.Exists(folderPath))
                return;

            using (WebClient client = new WebClient())
            {
                await client.DownloadFileTaskAsync(url, folderPath);
            }
        }
    }
}
