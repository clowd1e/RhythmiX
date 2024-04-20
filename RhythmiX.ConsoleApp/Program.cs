using RhythmiX.Service.API;
using RhythmiX.Service.API.ResponseModels;

namespace RhythmiX.ConsoleApp
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                TrackResponseModel? response = await ApiHelper.GetTrackByIdAsync(1532771);
                Console.WriteLine(response?.Results[0].Name);
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
