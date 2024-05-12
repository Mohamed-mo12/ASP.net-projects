using E_commerce.Models;
using E_commerce.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace E_commerce.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager; 
        public AccountController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;

        }
        [HttpGet]
        public IActionResult Register() {
            
            return View(); 
        
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel registerView) {

            if (ModelState.IsValid) 
            {
               ApplicationUser applicationUser = new ApplicationUser();
               applicationUser.Email = registerView.Email;
               applicationUser.UserName = registerView.Name;
               applicationUser.Address = registerView.Address;
               applicationUser.PasswordHash = registerView.Password;
               IdentityResult result = await userManager.CreateAsync(applicationUser,registerView.Password);
                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(applicationUser,false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }

               
            }

            return View(registerView); 
            
        
        }



        public IActionResult Login() {

            return View();
        
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel) {

         ApplicationUser userModel = await userManager.FindByNameAsync(loginViewModel.Name);
            if (userModel != null)
            {
            
           var found = await userManager.CheckPasswordAsync(userModel, loginViewModel.Password);
                if (found)
                {
                    await signInManager.SignInAsync(userModel,false);
                    return RedirectToAction("Index", "Home"); 
                }
                else
                {
                    ModelState.AddModelError("", "UserName and password invalid"); 
                }
            }


            return View(loginViewModel); 
           
        }

        public async Task<IActionResult> Logout() {


            await signInManager.SignOutAsync();
            return RedirectToAction("Index","Home");
        
        
        }

        
    }
}
