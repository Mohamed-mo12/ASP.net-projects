using E_commerce.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace E_commerce.Repository
{
    public class DevicesRepo : IDevicesRepo
    {
        private readonly ApplicationDbContext dbContext;
        public DevicesRepo(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext; 
        }
        public IEnumerable<SelectListItem> selectLists()
        {
            var Dev = dbContext.Devices.
                Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name })
                .OrderBy(d=>d.Text).AsNoTracking()
                .ToList();
            return Dev; 
        }
    }
}
