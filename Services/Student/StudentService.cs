using PracticeEFCore.DataContext;

namespace Services.Student;
using Model;
public class StudentService : IStudentService
{
    private readonly ConsoleAppDbContext dbContext;

    public StudentService(ConsoleAppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    public bool Create(Student student)
    {
        if (student == null!)
        {
            Console.WriteLine("Ваш студент null!");
            return false;
        }
        dbContext.Students.Add(student);
        int res = dbContext.SaveChanges();
        return res != 0;
    }

    public bool Update(Student student)
    {
        Student? updateStudent = dbContext.Students.Find(student.Id);
        if(updateStudent == null) return false;

        updateStudent.FirstName = student.FirstName;
        updateStudent.LastName = student.LastName;
        updateStudent.Age = student.Age;
        int res = dbContext.SaveChanges();
        return res != 0;
    }

    public bool Delete(int id)
    {
        Student? student = dbContext.Students.Find(id);
        if(student == null) return false;
        
        dbContext.Students.Remove(student);
        int res = dbContext.SaveChanges();
        return res != 0;
    }

    public Student? GetById(int id)
    {
        Student? student = dbContext.Students.FirstOrDefault(x => x.Id == id);
        if (student == null)
        {
            Console.WriteLine("Not Student");
            return null;
        }
        return student;
    }

    public IEnumerable<Student?> GetAll()
    {
        IEnumerable<Student?> students = dbContext.Students.ToList();
        if (students == null!)
        {
            Console.WriteLine("Not Students");
            return null!;
        }
        return students;
    }
}