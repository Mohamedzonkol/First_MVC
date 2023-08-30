using Microsoft.AspNetCore.Mvc;
namespace First_MVC.Controllers
{
    public class StateController : Controller
    {
        public IActionResult setCookie()
        {
           
            CookieOptions cookieOptions =new CookieOptions();
            cookieOptions.Expires=DateTimeOffset.Now.AddDays(2);


            Response.Cookies.Append("stdName1", "Mohemed", cookieOptions);   //persistent Cookie
            Response.Cookies.Append("stdName2", "Mohemed");                 //session Cookie


            return Content("saved Cookie");
        }
        public IActionResult getCookie() {

           string cookie1= Request.Cookies["stdName1"];
            string cookie2 = Request.Cookies["stdName2"];

            return Content($"Cookie1 is ={cookie1}  AND Cookie2 is ={cookie2}");

        }
        public IActionResult setState() {
            //state save

            string name = "Mohamed";
            int age = 25;
            HttpContext.Session.SetString("namestd", name);
            HttpContext.Session.SetInt32("agestd", age);
            return Content("saved");
        }
        public IActionResult getState()
        {
            string n = HttpContext.Session.GetString("namestd");
            int a = HttpContext.Session.GetInt32("agestd").Value;   //casting
            return Content($"Student Name IS {n} and ahe is {a}");
        }
        public IActionResult set()
        {
            TempData["Name"] = "MVC";
            return Content("Data Saved");
        }
        public IActionResult get1()
        {
            string name = "Empty";
            if (TempData.ContainsKey("Name"))
            {
                name = TempData["Name"].ToString();
                TempData.Keep("Name");//عشان السيشن ميمسحهاش تفضل موجوده
            }
            return Content($"get call2 temp data =  {name}");
        }
        public IActionResult get2()
        {
            string name = "Empty";
            if (TempData.ContainsKey("Name")) {
                name = TempData.Peek("Name").ToString();//بتجبها وبتعمل كمان keep في نفس الوقت
            }
            return Content($"get call2 temp data =  {name}");
        }
 
    }
}
