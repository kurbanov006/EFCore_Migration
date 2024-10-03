
namespace Services.Student;
using Model;

public interface IStudentService
{
    bool Create(Student student);
    bool Update(Student student);
    bool Delete(int id);
    Student? GetById(int id);
    IEnumerable<Student?> GetAll();
}