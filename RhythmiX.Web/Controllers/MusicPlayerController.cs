using Microsoft.AspNetCore.Mvc;
using RhythmiX.Service.Downloaders.TrackDownloader;
using RhythmiX.Service.Queries.Dtos;
using RhythmiX.Service.Queries.HistoryTrack;
using RhythmiX.Service.Queries.LikedTrack;
using RhythmiX.Storage.Entities;
using RhythmiX.Storage.Repository;
using RhythmiX.Web.Services;
using RhythmiX.Web.ViewModels;

namespace RhythmiX.Web.Controllers
{
    public class MusicPlayerController : Controller
    {
        private readonly IMusicRepository _musicRepository;
        public MusicPlayerController(IMusicRepository musicRepository)
        {
            _musicRepository = musicRepository;
        }

        public async Task<IActionResult> LikedAsync(long userId, long trackId)
        {
            GetUserLikedTracksQuery query = new GetUserLikedTracksQuery();
            GetUserLikedTracksQueryHandler handler = new GetUserLikedTracksQueryHandler(_musicRepository, userId);

            IEnumerable<Track> likedTracks = await handler.HandleAsync(query);
            if (likedTracks is null)
                RedirectToAction("Liked", "Main");

            int currentTrackIndex = likedTracks.ToList().FindIndex(t => t.ApiId == trackId);

            await TrackDownloader.DownloadTrackAsync(likedTracks.ToList()[currentTrackIndex], PathService.DownloadedTracksPath);

            IEnumerable<TrackDto> likedTrackDtos = likedTracks.Select(t => new TrackDto(t));
            TrackViewModel model = new TrackViewModel
            {
                Title = "Liked",
                UserId = userId,
                TrackId = trackId,
                CurrentTrackIndex = currentTrackIndex,
                Tracks = likedTracks,
                TrackDtos = likedTrackDtos
            };

            return View("Index", model);
        }

        public async Task<IActionResult> HistoryAsync(long userId, long trackId)
        {
            GetUserHistoryTracksQuery query = new GetUserHistoryTracksQuery();
            GetUserHistoryTracksQueryHandler handler = new GetUserHistoryTracksQueryHandler(_musicRepository, userId);

            IEnumerable<Track> historyTracks = await handler.HandleAsync(query);
            if (historyTracks is null)
                RedirectToAction("History", "Main");

            int currentTrackIndex = historyTracks.ToList().FindIndex(t => t.ApiId == trackId);

            await TrackDownloader.DownloadTrackAsync(historyTracks.ToList()[currentTrackIndex], PathService.DownloadedTracksPath);

            IEnumerable<TrackDto> historyTrackDtos = historyTracks.Select(t => new TrackDto(t));
            TrackViewModel model = new TrackViewModel
            {
                Title = "History",
                UserId = userId,
                TrackId = trackId,
                CurrentTrackIndex = currentTrackIndex,
                Tracks = historyTracks,
                TrackDtos = historyTrackDtos
            };

            return View("Index", model);
        }
    }
}
