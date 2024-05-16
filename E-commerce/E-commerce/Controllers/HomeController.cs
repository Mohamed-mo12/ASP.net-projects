using E_commerce.Models;
using E_commerce.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace E_commerce.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IGamesRepo _Game; 



        public HomeController(ILogger<HomeController> logger,IGamesRepo gamesRepo)
        {
            this._Game = gamesRepo; 
            _logger = logger;
        }

        public IActionResult Index()
        {
           var ReadingGames = _Game.GetAll();
            return View(ReadingGames);
        }

       

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
