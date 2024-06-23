using Microsoft.AspNetCore.Mvc;
using RhythmiX.Service.Command.User.Register;
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

        [HttpPost]
        public async Task<IActionResult> Index(RegisterUserCommand command)
        {
            RegisterUserCommandHandler handler = new RegisterUserCommandHandler(_userRepository);
            var result = await handler.HandleAsync(command);
            if (result.IsSuccess)
            {
                return RedirectToAction("Index", "Login");
            }

            return View(command);
        }
    }
}
