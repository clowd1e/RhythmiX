using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RhythmiX.Service.Queries.Dtos;
using RhythmiX.Service.Queries.HistoryTrack;
using RhythmiX.Service.Queries.LikedTrack;
using RhythmiX.Storage.Entities;
using RhythmiX.Storage.Repository;
using RhythmiX.Web.Services.UserService;
using RhythmiX.Web.ViewModels;

namespace RhythmiX.Web.Controllers
{
    [Authorize]
    public class MainController : Controller
    {
        private readonly IMusicRepository _musicRepository;
        private readonly IUserService _userService;
        public MainController(IMusicRepository musicRepository, IUserService userService)
        {
            _musicRepository = musicRepository;
            _userService = userService;
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
            GetUserLikedTracksQuery query = new GetUserLikedTracksQuery();
            GetUserLikedTracksQueryHandler handler = new GetUserLikedTracksQueryHandler(_musicRepository, _userService.Id);
            IEnumerable<Track> tracks = await handler.HandleAsync(query);
            if (tracks is null)
                return View(new List<TrackDto>());

            IEnumerable<TrackDto> trackDtos = tracks.Select(t => new TrackDto(t));
            TrackViewModel model = new TrackViewModel
            {
                UserId = _userService.Id,
                TrackDtos = trackDtos
            };

            return View(model);
        }

        public async Task<IActionResult> HistoryAsync()
        {
            GetUserHistoryTracksQuery query = new GetUserHistoryTracksQuery();
            GetUserHistoryTracksQueryHandler handler = new GetUserHistoryTracksQueryHandler(_musicRepository, _userService.Id);
            IEnumerable<Track> tracks = await handler.HandleAsync(query);
            if (tracks is null)
                return View(new List<TrackDto>());

            IEnumerable<TrackDto> trackDtos = tracks.Select(t => new TrackDto(t));
            TrackViewModel model = new TrackViewModel
            {
                UserId = _userService.Id,
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
