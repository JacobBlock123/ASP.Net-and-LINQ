using GamesWebsite.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GamesWebsite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Games()
        {
            VideoGameRepository repo = new VideoGameRepository();
            return View(repo);
        }

        public IActionResult GameDetails(string id)
        {
            VideoGameRepository repo = new VideoGameRepository();
            VideoGame game = repo.VideoGames.FirstOrDefault(i => i.Title.ToLower() == id.ToLower());
            return View(game);
        } 

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}