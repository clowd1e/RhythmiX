using Microsoft.AspNetCore.Mvc;
using RhythmiX.Service.Queries.Dtos;

namespace RhythmiX.Web.Controllers
{
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

        public IActionResult Liked()
        {
            List<TrackDto> tracks = new List<TrackDto>()
            {
                new TrackDto() { Id = 1, TrackName = "Something", ArtistName = "Igor", Image = "track_image_default.jpg", Duration = "3:35" },
                new TrackDto() { Id = 2, TrackName = "Really cool song", ArtistName = "NIRVANA", Image = "track_image_default.jpg", Duration = "5:14" },
                new TrackDto() { Id = 3, TrackName = "I need a really long song name so that it is really long", ArtistName = "Long group name so that it is really long", Image = "track_image_default.jpg", Duration = "63:35" },
                new TrackDto() { Id = 4, TrackName = "Something", ArtistName = "Igor", Image = "track_image_default.jpg", Duration = "3:35" },
                new TrackDto() { Id = 5, TrackName = "Something", ArtistName = "Igor", Image = "track_image_default.jpg", Duration = "3:35" },
                new TrackDto() { Id = 6, TrackName = "Something", ArtistName = "Igor", Image = "track_image_default.jpg", Duration = "3:35" },
                new TrackDto() { Id = 7, TrackName = "Something", ArtistName = "Igor", Image = "track_image_default.jpg", Duration = "3:35" }
            };

            return View(tracks);
        }

        public IActionResult History()
        {
            return View();
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
