using Microsoft.AspNetCore.Mvc;
using RhythmiX.Service.Queries.Dtos;
using RhythmiX.Service.Queries.LikedTrack;
using RhythmiX.Storage.Entities;
using RhythmiX.Storage.Repository;
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

        public async Task<IActionResult> IndexAsync(long userId, long trackId)
        {
            GetUserLikedTracksQuery query = new GetUserLikedTracksQuery();
            GetUserLikedTracksQueryHandler handler = new GetUserLikedTracksQueryHandler(_musicRepository, userId);

            IEnumerable<Track> likedTracks = await handler.HandleAsync(query);
            if (likedTracks is null)
                RedirectToAction("Liked", "Main");

            IEnumerable<TrackDto> likedTrackDtos = likedTracks.Select(t => new TrackDto(t));
            TrackViewModel model = new TrackViewModel
            {
                Title = "Liked",
                UserId = userId,
                TrackId = trackId,
                Tracks = likedTracks,
                TrackDtos = likedTrackDtos
            };

            return View(model);
        }
    }
}
