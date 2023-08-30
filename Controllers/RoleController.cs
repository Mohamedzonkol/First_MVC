using First_MVC.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace First_MVC.Controllers
{
    [Authorize(Roles ="Admin")]
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;

        public RoleController(RoleManager<IdentityRole> _roleManager)
        {
            roleManager = _roleManager;
        }

        //add ROLE
        public IActionResult addRole() {
        return View();
        }
        [HttpPost]
        public async Task <IActionResult> addRole(RoleViewModel newRole ) {
            if (ModelState.IsValid==true) {
                IdentityRole role=new IdentityRole() { Name=newRole.RoleName};
               IdentityResult result = await roleManager.CreateAsync(role);
                if (result.Succeeded)
                {

                    return View();
                }
                else {
                    foreach (var error in result.Errors) {
                        ModelState.AddModelError("",error.Description);
                    }
                
                }
            }    

        return View(newRole);
        }



        public IActionResult Index()
        {
            return View();
        }
    }
}
