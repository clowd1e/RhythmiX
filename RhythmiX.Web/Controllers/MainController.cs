using Microsoft.AspNetCore.Mvc;

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
            return View();
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
