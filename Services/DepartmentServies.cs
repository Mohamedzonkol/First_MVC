using First_MVC.Models;

namespace First_MVC.Services
{
    public class DepartmentServies : IDepartmentServies
    {
        AppDbContext context;
        public DepartmentServies(AppDbContext _context)
        {
            context = _context;
        }

        public List<Department> getAll()
        {
            return context.Department.ToList();
        }
        public Department getByID(int id)
        {
            return context.Department.FirstOrDefault(x => x.Id == id);
        }
        public void Crete(Department department)
        {
            context.Department.Add(department);
            context.SaveChanges();

        }
        public void Update(int id, Department department)
        {
            Department olddept = context.Department.FirstOrDefault(x => x.Id == id);
            olddept.Name = department.Name;
            olddept.MangerName = department.MangerName;
            context.SaveChanges();

        }
        public void Delete(int id)
        {
            Department dept = context.Department.FirstOrDefault(x => x.Id == id);
            context.Department.Remove(dept);
            context.SaveChanges();

        }
        public Department Get() {
            return new Department();
        }
    }
}
