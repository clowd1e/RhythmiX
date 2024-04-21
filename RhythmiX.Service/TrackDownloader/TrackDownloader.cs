using System.Net;

namespace RhythmiX.Service.TrackDownloader
{
    public static class TrackDownloader
    {
        public static async Task DownloadTrackAsync(string name, string path)
        {
            Uri url = new Uri(path);
            string savePath = $"../../../../RhythmiX.WPF/DownloadedMusic/{name}.mp3";

            if (File.Exists(savePath))
                return;

            using (WebClient client = new WebClient())
            {
                await client.DownloadFileTaskAsync(url, savePath);
            }
        }
    }
}
