using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using RhythmiX.Service.Command.User.Login;
using RhythmiX.Service.Queries.Dtos;
using RhythmiX.Service.Queries.User;
using RhythmiX.Storage.Entities;
using RhythmiX.Storage.Repository;
using RhythmiX.Web.Services.UserService;
using System.Security.Claims;

namespace RhythmiX.Web.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserService _userService;

        public LoginController(IUserRepository userRepository, IUserService userService)
        {
            _userRepository = userRepository;
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserDto model)
        {
            if (ModelState.IsValid)
            {
                LoginUserCommand command = new LoginUserCommand(model.Username, model.Password);
                LoginUserCommandHandler handler = new LoginUserCommandHandler(_userRepository);
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

                    GetUserQuery query = new GetUserQuery();
                    GetUserQueryHandler userHandler = new GetUserQueryHandler(_userRepository, new UserDto(model.Username, model.Password));
                    User user = await userHandler.HandleAsync(query);
                    
                    _userService.SetUser(user);

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
