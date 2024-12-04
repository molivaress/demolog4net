using System.Diagnostics;
using autenticacion.Models;
using Microsoft.AspNetCore.Mvc;

namespace autenticacion.Controllers
{
    public class AuthController : Controller
    {
        private readonly ILogger<AuthController> _logger;
        private readonly IConfiguration _config;

        public AuthController(ILogger<AuthController> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
        }

        public IActionResult Register()
        {
            string? aa = _config["testKey"] == null ? "test in local" : _config["testKey"];
            Console.WriteLine($"hola este es mi key ${aa}");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserModel userModel)
        {
            userModel.Password = "encryptedHash";
            //UserModel userCreated = await _userService.Save(userModel);
            //if (userCreated.IdUser > 0)
            //    return RedirectToAction("Login", "Auth");
            await Task.Delay(500);
            ViewData["Message"] = "Could not create user.";
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            await Task.Delay(500);
            Console.WriteLine($"username: {email} / password {password}");
            if (email == "admin" && password == "admin")
            {
                return RedirectToHome();
            }

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult RedirectToHome()
        {
            var homeApp = _config["HOME_APP"] ?? "http://localhost:5237/";
            return Redirect(homeApp);
        }
    }
}