using First_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace First_MVC.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public string getInfo() {

            return "THIS IS FIRST BACKEND PAGE";
        }
        public IActionResult getContent() {

            ContentResult cont =new ContentResult();
            cont.Content="The Firt Controller";
            return cont;
        }
        public IActionResult getView() { 
        ViewResult view =new ViewResult();
        view.ViewName = "Firstview";
        return view;
        }
        public IActionResult Show(int num) { 
         
            if(num % 2==0) 
            { 
            return Content("This Num Is Even");

            }
            else
            {   
                return View ("This Is Num Is Odd");
            }
        
        }
        public IActionResult getProuduct() { 
        //This is Model
        List<Prouduct> prouducts = ProuctList.Products.ToList();
            return View("getprouducts", prouducts);
        
        }
        public IActionResult SearchProuduct(int id) {
            Prouduct proModel = ProuctList.Products.FirstOrDefault(p => p.Id == id);

            return View("Details", proModel);
        }

    }
}
