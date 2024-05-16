using Microsoft.AspNetCore.Mvc.Rendering;

namespace E_commerce.Repository
{
    public interface ICategoriesRepo
    {
        IEnumerable<SelectListItem> selectLists(); 
    }
}
