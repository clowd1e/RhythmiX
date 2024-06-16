using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RhythmiX.Service.Queries.Dtos;
using RhythmiX.Service.Queries.HistoryTrack;
using RhythmiX.Service.Queries.LikedTrack;
using RhythmiX.Storage.Entities;
using RhythmiX.Storage.Repository;
using RhythmiX.Web.ViewModels;

namespace RhythmiX.Web.Controllers
{
    [Authorize]
    public class MainController : Controller
    {
        private readonly IMusicRepository _musicRepository;
        public MainController(IMusicRepository musicRepository)
        {
            _musicRepository = musicRepository;
        }

        public IActionResult Home()
        {
            return View();
        }

        public IActionResult Explore()
        {
            return View();
        }

        public async Task<IActionResult> LikedAsync()
        {
            User user = new User("Abanent2", "Abanent2") { Id = 12 };
            GetUserLikedTracksQuery query = new GetUserLikedTracksQuery();
            GetUserLikedTracksQueryHandler handler = new GetUserLikedTracksQueryHandler(_musicRepository, user);
            IEnumerable<Track> tracks = await handler.HandleAsync(query);
            if (tracks is null)
                return View(new List<TrackDto>());

            IEnumerable<TrackDto> trackDtos = tracks.Select(t => new TrackDto(t));
            TrackViewModel model = new TrackViewModel
            {
                UserId = user.Id,
                TrackDtos = trackDtos
            };

            return View(model);
        }

        public async Task<IActionResult> HistoryAsync()
        {
            User user = new User("Abanent2", "Abanent2") { Id = 12 };
            GetUserHistoryTracksQuery query = new GetUserHistoryTracksQuery();
            GetUserHistoryTracksQueryHandler handler = new GetUserHistoryTracksQueryHandler(_musicRepository, user);
            IEnumerable<Track> tracks = await handler.HandleAsync(query);
            if (tracks is null)
                return View(new List<TrackDto>());

            IEnumerable<TrackDto> trackDtos = tracks.Select(t => new TrackDto(t));
            TrackViewModel model = new TrackViewModel
            {
                UserId = user.Id,
                TrackDtos = trackDtos
            };

            return View(model);
        }

        public IActionResult Playlists()
        {
            return View();
        }

        public IActionResult Account()
        {
            return View();
        }
    }
}
