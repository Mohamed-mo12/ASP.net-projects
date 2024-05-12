using E_commerce.Models;
using E_commerce.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace E_commerce.Controllers
{
    public class RoleController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager; 
       
        private readonly RoleManager<IdentityRole> roleManager; 
        public RoleController(RoleManager<IdentityRole> roleManager,UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager; 
            this.roleManager = roleManager;

        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult AddRole() { 
        
            
            return View();
        
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> AddRole(RoleViewModel roleViewModel) {
            IdentityRole identityRole = new IdentityRole();
            identityRole.Name = roleViewModel.RoleName;
            IdentityResult result = await roleManager.CreateAsync(identityRole);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
            
            return View(roleViewModel);
        
        }

        [HttpGet]
        public IActionResult AddUserToRole() {

            return View();
        
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddUserToRole(AddUserToRoleViewModel addUserToRoleViewModel) {
            if (ModelState.IsValid)
            {
             
          ApplicationUser userModel  =await userManager.FindByNameAsync(addUserToRoleViewModel.Name);
                if (userModel!=null)
                {
                var found = await userManager.CheckPasswordAsync(userModel, addUserToRoleViewModel.Password);
                    if (found)
                    {
            var Rolexist = await roleManager.RoleExistsAsync(addUserToRoleViewModel.RoleName);
                        if (!Rolexist)
                        {
                            ModelState.AddModelError(string.Empty, "Role Not Found");
                            return View(addUserToRoleViewModel);
                        }
                        else
                        {
                    IdentityResult result = await userManager.AddToRoleAsync(userModel, addUserToRoleViewModel.RoleName);
                            if (result.Succeeded)
                            {
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
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "UserName and password invalid");
                    }    
                }

            }


            return View(addUserToRoleViewModel);
        
        }
    }
}
