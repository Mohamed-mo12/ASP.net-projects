using Microsoft.AspNetCore.Mvc.Rendering;

namespace E_commerce.Repository
{
    public interface IDevicesRepo
    {
        IEnumerable<SelectListItem> selectLists();

    }
}
