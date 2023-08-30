using First_MVC.Models;

namespace First_MVC.Services
{
    public interface IDepartmentServies
    {
        void Crete(Department department);
        void Delete(int id);
        List<Department> getAll();
        Department getByID(int id);
        void Update(int id, Department department);
        Department Get();

    }
}