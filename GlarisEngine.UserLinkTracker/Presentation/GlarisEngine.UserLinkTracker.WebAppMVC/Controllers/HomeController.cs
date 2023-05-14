using GlarisEngine.UserLinkTracker.Domain.Authentication;
using GlarisEngine.UserLinkTracker.ServiceInterface;
using GlarisEngine.UserLinkTracker.WebAppMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GlarisEngine.UserLinkTracker.WebAppMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IAuthenticationService _authenticationService;
        public HomeController(ILogger<HomeController> logger, IAuthenticationService authenticationService)
        {
            this._logger = logger;
            this._authenticationService = authenticationService;
        }

        public async Task<IActionResult> Index()
        {
            List<User> users = new List<User>();
            users = await this._authenticationService.GetAllUsersAsync();
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
    }
}