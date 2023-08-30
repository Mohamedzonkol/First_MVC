using First_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using First_MVC.ViewModel;
namespace First_MVC.Controllers
{
    public class PassDataController : Controller
    {
        AppDbContext context = new AppDbContext();
        public IActionResult Index()
        {
            //Extra Data
            List<string> Branches = new List<string>();
            Branches.Add("Alex");
            Branches.Add("Cairo");
            Branches.Add("Mnofia");
            Branches.Add("Zag");
            Branches.Add("new Vailge");
            ViewData["BranchesView"] = Branches;
            ViewData["String"] = "this is second view";
            ViewBag.data = DateTime.Now.ToString();



            List<Department> DeptModel = context.Department.ToList();

            return View(DeptModel);

        }
        public string getInfo()
        {

            return "THIS IS FIRST BACKEND PAGE";
        }
        public IActionResult ShowStudent(int id) {
            Student StudentModel = context.Student.Include(x => x.Department).FirstOrDefault(x =>x.Id==id) ;
        StNameWithDpNameViewModel stdVm=new StNameWithDpNameViewModel();
            stdVm.StudentName = StudentModel.Name;
            stdVm.DeptName = StudentModel.Department.Name;
            stdVm.Id = StudentModel.Id;
            return View("ShowStudent", stdVm);
        
        }

    }
}
