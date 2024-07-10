using Kitchen.Data;
using Kitchen.DTO;
using Kitchen.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kitchen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepo orderRepo; 
        public OrderController(IOrderRepo orderRepo)
        {
            this.orderRepo = orderRepo; 
        }


        [HttpPost("Create")]
        public async Task<IActionResult> Create(OrderDataDTO orderDataDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await orderRepo.Create(orderDataDTO);
                    return Ok(result); 
                }
                return BadRequest(ModelState);
            }
            catch (Exception ex)
            {

                return StatusCode(500, new { message = ex.Message }); 
            }
        }
    }
}
