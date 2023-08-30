using First_MVC.Models;

namespace First_MVC.Services
{
    public class StudentServies : IStudentServies
    {
        AppDbContext context;
        public StudentServies(AppDbContext _context)
        {
            context=_context;
        }

        public List<Student> getAll()
        {
            return context.Student.ToList();
        }
        public Student getByID(int id)
        {
            return context.Student.FirstOrDefault(x => x.Id == id);
        }
        public Student getByName(string name)
        {
            return context.Student.FirstOrDefault(x => x.Name == name);
        }
        public List<Student> getByDeptId(int deptId)
        {
            return context.Student.Where(x => x.Dept == deptId).ToList();
        }
        public void Crete(Student student)
        {
            context.Student.Add(student);
            context.SaveChanges();

        }
        public void Update(int id, Student student)
        {
            Student oldStudent = context.Student.FirstOrDefault(x => x.Id == id);
            oldStudent.Name = student.Name;
            oldStudent.Adress = student.Adress;
            oldStudent.Age = student.Age;
            oldStudent.Image = student.Image;
            oldStudent.Dept = student.Dept;
            context.SaveChanges();

        }
        public void Delete(int id)
        {
            Student std = context.Student.FirstOrDefault(x => x.Id == id);
            context.Student.Remove(std);
            context.SaveChanges();

        }

    }
}
