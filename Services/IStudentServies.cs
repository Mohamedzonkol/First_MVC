using First_MVC.Models;

namespace First_MVC.Services
{
    public interface IStudentServies
    {
        //CRUD OPERTION
        void Crete(Student student);
        void Delete(int id);
        List<Student> getAll();
        List<Student> getByDeptId(int deptId);
        Student getByID(int id);
        Student getByName(string name);
        void Update(int id, Student student);
    }
}