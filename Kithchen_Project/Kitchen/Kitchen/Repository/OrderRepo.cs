using Kitchen.Data;
using Kitchen.DTO;
using Kitchen.Model;

namespace Kitchen.Repository
{
    public class OrderRepo : IOrderRepo
    {
        
        private readonly ApplicationDbContext context;
        public OrderRepo(ApplicationDbContext context)
        {
            this.context = context; 
        }

        public async Task<DeliveryOrder> Create(OrderDataDTO orderData)
        {
            DeliveryOrder order = new DeliveryOrder
            {
                Name = orderData.Name,
                Address = orderData.Address,
                Email = orderData.Email,
                Phone = orderData.Phone,
                Notes = orderData.Notes
            };

            await context.DeliveryOrders.AddAsync(order);
            await context.SaveChangesAsync();
            return order;
        }
    }
}
