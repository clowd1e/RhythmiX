using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RhythmiX.Service.Queries.Dtos;
using RhythmiX.Service.Queries.LikedTrack;
using RhythmiX.Storage;
using RhythmiX.Storage.Entities;
using RhythmiX.Storage.Repository;

namespace RhythmiX.Web.Controllers
{
    [Authorize]
    public class MainController : Controller
    {
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
            //List<TrackDto> tracks = new List<TrackDto>()
            //{
            //    new TrackDto() { Id = 1, TrackName = "Something", ArtistName = "Igor", Image = "track_image_default.jpg", Duration = "3:35" },
            //    new TrackDto() { Id = 2, TrackName = "Really cool song", ArtistName = "NIRVANA", Image = "track_image_default.jpg", Duration = "5:14" },
            //    new TrackDto() { Id = 3, TrackName = "I need a really long song name so that it is really long", ArtistName = "Long group name so that it is really long", Image = "track_image_default.jpg", Duration = "63:35" },
            //    new TrackDto() { Id = 4, TrackName = "Something", ArtistName = "Igor", Image = "track_image_default.jpg", Duration = "3:35" },
            //    new TrackDto() { Id = 5, TrackName = "Something", ArtistName = "Igor", Image = "track_image_default.jpg", Duration = "3:35" },
            //    new TrackDto() { Id = 6, TrackName = "Something", ArtistName = "Igor", Image = "track_image_default.jpg", Duration = "3:35" },
            //    new TrackDto() { Id = 7, TrackName = "Something", ArtistName = "Igor", Image = "track_image_default.jpg", Duration = "3:35" }
            //};

            using MusicDbContext context = new MusicDbContext();
            MusicRepository musicRepository = new MusicRepository(context);

            User user = new User("Abanent2", "Abanent2") { Id = 12 };
            GetUserLikedTracksQuery query = new GetUserLikedTracksQuery();
            GetUserLikedTracksQueryHandler handler = new GetUserLikedTracksQueryHandler(musicRepository, user);
            IEnumerable<Track> tracks = await handler.HandleAsync(query);
            if (tracks is null)
                return View(new List<TrackDto>());

            IEnumerable<TrackDto> trackDtos = tracks.Select(t => new TrackDto(t));

            return View(trackDtos);
        }

        public IActionResult History()
        {
            List<TrackDto> tracks = new List<TrackDto>();

            return View(tracks);
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
