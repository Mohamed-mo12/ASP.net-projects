using E_commerce.Models;
using E_commerce.Setting;
using E_commerce.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DiaSymReader;
using Microsoft.EntityFrameworkCore;

namespace E_commerce.Repository
{
    public class GamesRepo : IGamesRepo
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly string _imagepath; 
        public GamesRepo(ApplicationDbContext dbContext,
            IWebHostEnvironment webHostEnvironment)
        {
            this.webHostEnvironment = webHostEnvironment;
            this.dbContext = dbContext;
            this._imagepath = $"{webHostEnvironment.WebRootPath}{FileSetting.ImagePath}";
        }
        public async Task Create(CreateGameViewModel Game)
        {

            var CoverName = $"{Guid.NewGuid()}{Path.GetExtension(Game.Cover.FileName)}";
            var path = Path.Combine(_imagepath,CoverName);

            using var stream = File.Create(path);
            await Game.Cover.CopyToAsync(stream);

            Game game = new()
            {
                Name = Game.Name,
                Description = Game.Description,
                Cover = CoverName,
                CategoryId = Game.CategoryId,
                Device = Game.selectedDevice.Select(x=> new GameDevice {DeviceId = x}).ToList()
            };

            dbContext.Games.Add(game);
            dbContext.SaveChanges(); 
            
        }

        public void Delete(int id)
        {
            var result = dbContext.Games.FirstOrDefault(x => x.Id == id);
            dbContext.Games.Remove(result);
            dbContext.SaveChanges();
        }

        public List<Game> GetAll()
        {
            var result = dbContext.Games.Include(x=>x.category).
                Include(g=>g.Device).ThenInclude(d=>d.Device)
                .AsNoTracking()
                .ToList();
            return result; 

        }

        public Game? GetDetails(int id)
        {
            var Details = dbContext.Games.Include(x => x.category).
                Include(x=>x.Device).ThenInclude(x=>x.Device)
                .AsNoTracking()
                .FirstOrDefault(x => x.Id == id);
                
            return Details; 
        }

        public async Task<Game?> Update(UpdateViewModel update)
        {
            var result = dbContext.Games.Include(x => x.Device)
                .FirstOrDefault(x => x.Id == update.Id);
            if (result ==null)
            {
                return null; 
            }
            result.Name = update.Name;
            result.Description = update.Description;
            result.CategoryId = update.CategoryId;
            result.Device = update.selectedDevice.Select(x => new GameDevice {DeviceId=x}).ToList();
            dbContext.SaveChanges();

            return result; 
            
        }
    }
}
