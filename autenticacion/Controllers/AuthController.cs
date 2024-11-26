using System.Diagnostics;
using autenticacion.Models;
using Microsoft.AspNetCore.Mvc;

namespace autenticacion.Controllers
{
    public class AuthController : Controller
    {
        private readonly ILogger<AuthController> _logger;

        public AuthController(ILogger<AuthController> logger)
        {
            _logger = logger;
        }

        public IActionResult Register()
        {
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

            ViewData["Message"] = "User or password is incorrect.";
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
            var urlDashboardHome = "http://localhost:5237/";
            return Redirect(urlDashboardHome);
        }
    }
}