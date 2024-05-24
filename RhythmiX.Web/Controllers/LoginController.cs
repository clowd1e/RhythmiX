using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using RhythmiX.Service.Command.User.Login;
using RhythmiX.Service.Queries.Dtos;
using RhythmiX.Storage;
using RhythmiX.Storage.Repository;
using System.Security.Claims;

namespace RhythmiX.Web.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserDto model)
        {
            if (ModelState.IsValid)
            {
                using MusicDbContext context = new MusicDbContext();
                UserRepository userRepository = new UserRepository(context);

                LoginUserCommand command = new LoginUserCommand(model.Username, model.Password);
                LoginUserCommandHandler handler = new LoginUserCommandHandler(userRepository);
                var result = await handler.HandleAsync(command);
                if (result.IsSuccess)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, model.Username)
                    };

                    var claimsIdentity = new ClaimsIdentity(
                        claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    var authProperties = new AuthenticationProperties();

                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity),
                        authProperties);

                    return RedirectToAction("Home", "Main");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return View(model);
                }
            }
            return View(model);
        }
    }
}
