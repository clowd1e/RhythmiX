using RhythmiX.Service.API;
using RhythmiX.Service.API.ResponseModels;
using RhythmiX.Service.Downloaders.TrackDownloader;
using RhythmiX.Service.Downloaders.ZipDownloader;

namespace RhythmiX.ConsoleApp
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            TrackResponseModel? response = await ApiHelper.GetObjectByIdAsync<TrackResponseModel>("tracks", 1532772, "&include=musicinfo");
            Console.WriteLine(response.Results[0].Name);
            await TrackDownloader.DownloadTrackAsync(response, "../../../../RhythmiX.WPF/APICallResults/DownloadedMusic");

            ArtistResponseModel? artistResponse = await ApiHelper.GetObjectByIdAsync<ArtistResponseModel>("artists", response.Results[0].ArtistId);
            Console.WriteLine(artistResponse.Results[0].Name);




            AlbumResponseModel? albumResponse = await ApiHelper.GetObjectByIdAsync<AlbumResponseModel>("albums", 104336);
            Console.WriteLine(albumResponse.Results[0].Name);
            await ZipDownloader.DownloadAlbumAsync(albumResponse, "../../../../RhythmiX.WPF/APICallResults/DownloadedAlbums");



            PlaylistResponseModel? playlistResponse = await ApiHelper.GetObjectByIdAsync<PlaylistResponseModel>("playlists", 218691);
            Console.WriteLine(albumResponse.Results[0].Name);
            await ZipDownloader.DownloadPlaylistAsync(playlistResponse, "../../../../RhythmiX.WPF/APICallResults/DownloadedPlaylists");
        }
    }
}
