using Microsoft.AspNetCore.Mvc;
using RhythmiX.Storage.Repository;

namespace RhythmiX.Web.Controllers
{
    public class SignupController : Controller
    {
        private readonly IUserRepository _userRepository;
        public SignupController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
