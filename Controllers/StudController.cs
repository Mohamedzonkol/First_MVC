using First_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using First_MVC.Services;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace First_MVC.Controllers
{
    //    [AllowAnonymous] //by defult

    public class StudController : Controller
    {
        IStudentServies StudentServies;
        IDepartmentServies DepartmentServies;
        public StudController(IStudentServies _stdServ, IDepartmentServies _deptServ)
        {
            StudentServies= _stdServ;
            DepartmentServies=  _deptServ;
        }
        public IActionResult TestAjax() { 
        
        return View();
        }
       public IActionResult testPartial(int stdid) 
        {
            
            return PartialView("_StudentCard",StudentServies.getByID(stdid));
         
        }

        //remote validation
        public IActionResult Name_Exist(string Name,int id ) //must the same name of proparty 
                                                                    //علي عكس ان اي اسم عادي custon validation
        {
            Student student = StudentServies.getByName(Name);

            if (id == 0)  //add
            {
                if (student == null) //name not exist in database
                {
                    return Json(true);
                }
                else
                { ///name exist in db
                    return Json(false);
                }
            }
            else //edit
            {
                if (student == null) 
                {
                    return Json(true);//update name with new value not exist befor

                }
                else
                {
                    //object id==id parmeter true
                    if (student.Id == id)//name not change
                        return Json(true);
                    else
                        return Json(false);//chaged in name with value alread found
                }
            }
        }
        public IActionResult Add()
        {
            List<Department> departments = DepartmentServies.getAll();
            ViewData["Depts"] = departments;
            return View();
        }
        [HttpPost]
        public IActionResult SaveAdd(Student std)
        {
            if (ModelState.IsValid == true)
            {
               StudentServies.Crete(std);
                return RedirectToAction("Index");
            }
           // else if (std.Name != "ITI")
           // {
           //     ModelState.AddModelError("myName", "NAme Must Be ITI");//not relate to specific model property
           // }
            List<Department> departments = DepartmentServies.getAll();
            ViewData["Depts"] = departments;
            return View("Add", std);
        }
    //    [ActionName("SSS")] ///بدل مندها باسم edit هندها باسم sss
        public IActionResult Edit(int id)
        {

            List<Department> dept = DepartmentServies.getAll();
            ViewData["Department"] = dept;
            Student std = StudentServies.getByID(id);
            return View(std);
        }
        // [HttpPost]
        [HttpPost]
        public IActionResult  saveEdit([FromRoute]int Id , Student newStudent)
        
      {
            if (ModelState.IsValid == true)
            {

                StudentServies.Update(Id, newStudent);
                return RedirectToAction("Index");

            }
            List<Department> departments = DepartmentServies.getAll();
            ViewData["Department"] = departments;
            return View("Edit", newStudent);

        }
        public IActionResult Detalis(int id) {
            Student std = StudentServies.getByID(id);
            return View(std);
        }
        public IActionResult Delete(int id) {
            try {
               StudentServies.Delete(id);
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Exception", ex.InnerException.Message);
                return View("Detalis");
            }
            
            }
        public IActionResult getInfo()
        {
            return Content("OK");
        }
        public IActionResult Index()
        {
            return View(StudentServies.getAll());
        }

    }
}
