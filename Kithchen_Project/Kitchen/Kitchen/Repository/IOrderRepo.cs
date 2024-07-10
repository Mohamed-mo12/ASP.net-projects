using Kitchen.DTO;
using Kitchen.Model;

namespace Kitchen.Repository
{
    public interface IOrderRepo
    {
        Task<DeliveryOrder> Create(OrderDataDTO orderData);
    }
}
