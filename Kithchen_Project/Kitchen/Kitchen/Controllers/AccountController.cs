using Kitchen.Data;
using Kitchen.DTO;
using Kitchen.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Kitchen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ApplicationDbContext context; 
        private readonly UserManager<ApplicationUser> userManager;
        public AccountController(UserManager<ApplicationUser> userManager,
            ApplicationDbContext context)
        {
            this.context = context; 
            this.userManager = userManager; 
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Regsiter(RegisterDataDTO register) 
        {
            if (ModelState.IsValid)
            {
                ApplicationUser User = new ApplicationUser
                {
                    UserName = register.Name,
                    PasswordHash = register.Password,
                    Email = register.Email,
                    Subscription_Duration = register.Subscription
                };
               IdentityResult result = await userManager.CreateAsync(User, register.Password);
                if (result.Succeeded)
                {
                    return Ok(new { message = "User added successfully" });
                }
                else
                {
                    var errors = result.Errors.Select(e => e.Description);
                    return BadRequest(new { errors = errors });
                }
                
            }
            return BadRequest(ModelState);
        }

       

    }

}
