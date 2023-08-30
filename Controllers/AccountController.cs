using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using First_MVC.ViewModel;
namespace First_MVC.Controllers

{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager; //create cookie

        public AccountController(UserManager<IdentityUser> _userManager,SignInManager<IdentityUser> _signInManager )
        {
            userManager = _userManager;
            signInManager = _signInManager;
        }
        // -----------------regestier------------------------------
        //action open link
        public IActionResult Regestertion()
        {

            return View();
        }
        //action from db
        [HttpPost]
        public async Task<IActionResult>Regestertion(ResisterAccountViewModel newAccount ) { 
       
            if (ModelState.IsValid==true)
            { //create a user and create cookie
                IdentityUser user = new IdentityUser();
                //mapping 
                user.UserName = newAccount.Name;
                user.Email = newAccount.Email;
              IdentityResult result= await userManager.CreateAsync(user, newAccount.Password);
                if (result.Succeeded)
                {
                    //add role
                    await userManager.AddToRoleAsync(user,"Student");
                    //create cookie
                    await signInManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Dept");
                }
                else {
                    foreach (var error in result.Errors) {

                        ModelState.AddModelError("",error.Description);
                    }
            
                
                }
            }
            return View(newAccount);
           
        }



        //---------------------------------------login---------------------------------------
        //open link
        public IActionResult Login(string returnUrl = "~/Dept/Index") { 
        ViewBag.ReturnUrl = returnUrl;
        return View();
        }
        //check 
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel LoginUser, string returnUrl = "~/Dept/Index") {
            if (ModelState.IsValid==true)
            {
                IdentityUser User = await userManager.FindByNameAsync(LoginUser.UserName);
                if (User != null)
                {
                    Microsoft.AspNetCore.Identity.SignInResult result =
                  await signInManager.PasswordSignInAsync(User, LoginUser.Password, LoginUser.RememberMe, false);
                    if (result.Succeeded)
                    {
                       // return RedirectToAction("Index", "Dept");
                       return LocalRedirect(returnUrl);
                    }
                    else
                    {
                        ModelState.AddModelError("", " Incorerrct User Name Or Password");

                    }
                }

                else
                {
                    ModelState.AddModelError("", "Invaild User Name Or Password");

                }
            }
            return View(LoginUser);
        }
        //-----------------------logout------------
        public async Task <IActionResult> Logout() {
           await signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }
        public ActionResult addAdmin() {
        return View("Regestertion");
        
        }
        [HttpPost]
        public async Task<IActionResult> addAdmin(ResisterAccountViewModel newAccount)
        {

            if (ModelState.IsValid == true)
            { //create a user and create cookie
                IdentityUser user = new IdentityUser();
                user.UserName = newAccount.Name;
                user.Email = newAccount.Email;
                IdentityResult result = await userManager.CreateAsync(user, newAccount.Password);
                if (result.Succeeded)
                {
                    //add to admin role
                     await   userManager.AddToRoleAsync(user,"Admin");
                    //create cookie
                    await signInManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Dept");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {

                        ModelState.AddModelError("", error.Description);
                    }


                }
            }
            return View(newAccount);

        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
