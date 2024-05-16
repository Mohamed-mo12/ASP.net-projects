using E_commerce.Models;
using E_commerce.Repository;
using E_commerce.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering; 

namespace E_commerce.Controllers
{
    [Authorize]
    public class GamesController : Controller
    {
        
        
        private readonly ICategoriesRepo _categories;
        private readonly IDevicesRepo _devicesRepo;
        private readonly IGamesRepo _gameRepo; 
        public GamesController(ApplicationDbContext applicationDb,
            ICategoriesRepo categories,IDevicesRepo devicesRepo,
            IGamesRepo gamesRepo)
        {
            this._gameRepo = gamesRepo; 
            this._devicesRepo = devicesRepo;
            this._categories = categories; 
            
        }
        public IActionResult Index()
        {
            var result =_gameRepo.GetAll();
            return View(result);
        
        }

        [HttpGet]
         public IActionResult Create() {
            CreateGameViewModel viewModel = new()
            {
                Categories = _categories.selectLists(),
                Devices = _devicesRepo.selectLists()
            };

            return View(viewModel);
        
         }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateGameViewModel createGameView) {

            if (ModelState.IsValid==false)
            {
            createGameView.Categories = _categories.selectLists();
            createGameView.Devices = _devicesRepo.selectLists(); 

              return View(createGameView); 
            }


            await  _gameRepo.Create(createGameView); 
            return RedirectToAction(nameof(Index));  
        
        
        }

        [HttpGet]
        public IActionResult Details(int id) {

            var Details = _gameRepo.GetDetails(id);
            if (Details==null)
            {
                return NotFound();
            }
            return View(Details);
           
        
        
        }


        [HttpGet]
        public IActionResult Update(int id)
        {
            var Update = _gameRepo.GetDetails(id);
            if (Details == null)
            {
                return NotFound();
            }

            UpdateViewModel viewModel = new() {

                Id = id,
                Name = Update.Name,
                CategoryId = Update.CategoryId,
                Description = Update.Description,
                selectedDevice = Update.Device.Select(x => x.DeviceId).ToList(),
                Categories = _categories.selectLists(),
                Devices = _devicesRepo.selectLists()
            };



            return View(viewModel);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(UpdateViewModel update)
        {

            if (ModelState.IsValid == false)
            {
                update.Categories = _categories.selectLists();
                update.Devices = _devicesRepo.selectLists();

                return View(update);
            }


            var newgame =await _gameRepo.Update(update);
            if (newgame ==null)
            {
                return BadRequest();
            }

            return RedirectToAction(nameof(Index));


        }

        public IActionResult Delete(int id) {

            _gameRepo.Delete(id);
            return RedirectToAction("Index","Games");  
        
        }






    }
}
