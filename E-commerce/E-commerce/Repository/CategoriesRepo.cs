using E_commerce.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace E_commerce.Repository
{
    
    public class CategoriesRepo : ICategoriesRepo
    {
        private readonly ApplicationDbContext dbContext;
        public CategoriesRepo(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext; 
        }
        public IEnumerable<SelectListItem> selectLists()
        {
            var Categories = dbContext.Categories
           .Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name }).ToList();
            return Categories; 
        }
    }
}
