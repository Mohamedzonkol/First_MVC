using First_MVC.Models;
using First_MVC.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace First_MVC.Controllers
{
    public class DeptController : Controller
    {

        IStudentServies StudentServies;
        IDepartmentServies DepartmentServies;
        public DeptController(IStudentServies _stdServ, IDepartmentServies _deptServ)
        {
            StudentServies = _stdServ;
            DepartmentServies = _deptServ;
        }


        public IActionResult testHelper()
        {
            return View();
        }
        [Authorize]
        public IActionResult addDb()
        { 
        Department dept =DepartmentServies.Get();
        return View(dept);
        }
        public IActionResult SaveAdd(Department newdept)
        {
          //  if (newdept.Name != null && newdept.MangerName != null)     قديما   
          if(ModelState.IsValid == true)   ///حديثا  
            {
                //save db
                DepartmentServies.Crete(newdept);
                //display index view
                return RedirectToAction("Index");//csharp//index action name not viewNAme
            }
            return View("addDb", newdept);//html

        }
        [Authorize]

        public IActionResult Index()
        {
            List<Department> deptList =DepartmentServies.getAll();
            return View("Index", deptList);
        }
        public ActionResult testBind(int id,string name,Department dept) 
        {

            return Content("OK");
            //URL
            //http://localhost:26903/Dept/testBind/100?name=ali&mangername=kresten
        }
        public IActionResult testBindDic(Dictionary<string, int> Phones, int id)
        {
            return Content($"ok \n   id= {id} the pone is {Phones}\n");

            //Url is 
            //http://localhost:26903/Dept/testBindDic/?id=5&phones[moheamed]=0125555
        }
        public IActionResult testBinding(int id, int salary, string name, int[] degree)
        {
            return Content($"OK id={id} \t salary={salary} \t name={name} \n degree[0]={degree[0]} degree[1]={degree[1]}");

        //Url is
        //http://localhost:26903/Dept/testBinding/?id=5&salary=5540&name=mohamed&degree=5&degree=4
        }
        public string getInfo()
        {

            return "THIS IS FIRST BACKEND PAGE";
        }
    }
}
