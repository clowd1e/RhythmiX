using Microsoft.AspNetCore.Mvc;

namespace RhythmiX.Web.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
