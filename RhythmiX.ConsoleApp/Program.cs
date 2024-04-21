using RhythmiX.Service.API;
using RhythmiX.Service.API.ResponseModels;
using RhythmiX.Service.TrackDownloader;

namespace RhythmiX.ConsoleApp
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                TrackResponseModel? response = await ApiHelper.GetObjectByIdAsync<TrackResponseModel>("tracks", 1532771, "&include=musicinfo");
                Console.WriteLine(response.Results[0].Name);
                await TrackDownloader.DownloadTrackAsync(response.Results[0].Name, response.Results[0].AudioDownload);

                ArtistResponseModel? artistResponse = await ApiHelper.GetObjectByIdAsync<ArtistResponseModel>("artists", response.Results[0].ArtistId);
                Console.WriteLine(artistResponse.Results[0].Name);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
