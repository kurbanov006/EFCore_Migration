

using Model;
using PracticeEFCore.DataContext;
using Services.Student;


// Create 
using (ConsoleAppDbContext dbContext = new ConsoleAppDbContext())
{
    dbContext.Database.EnsureCreated();
    StudentService studentService = new StudentService(dbContext);
    
    Student student = new Student() { Id = 5, FirstName = "Komil", LastName = "Ziyaev", Age = 19};

    studentService.Create(student);
}

// Update 
using (ConsoleAppDbContext dbContext = new ConsoleAppDbContext())
{
    StudentService studentService = new StudentService(dbContext);

    Student student = new Student(){ Id = 1, FirstName = "Ali", LastName = "Kurbanov", Age = 19 };
    studentService.Update(student);
}

// Delete
using (ConsoleAppDbContext dbContext = new ConsoleAppDbContext())
{
    int id = 4;
    StudentService studentService = new StudentService(dbContext);
    studentService.Delete(id);
}

// Get By Id
using (ConsoleAppDbContext dbContext = new ConsoleAppDbContext())
{
    int id = 1;
    StudentService studentService = new StudentService(dbContext);
    var res = studentService.GetById(id);
    Console.WriteLine
    ($"Id: {res?.Id}, FirstName: {res?.FirstName}, LastName: {res?.LastName}, Age: {res?.Age}");
}

// Get All
using (ConsoleAppDbContext dbContext = new ConsoleAppDbContext())
{
    StudentService studentService = new StudentService(dbContext);
    IEnumerable<Student?> students = studentService.GetAll();
    foreach (var student in students)
        Console.WriteLine(@$"Id: {student?.Id}, FirstName: {student?.FirstName}, LastName: {student?.LastName}, Age: {student?.Age}");
}