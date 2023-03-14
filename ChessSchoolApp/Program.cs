using ChessSchoolApp.Data;
using ChessSchoolApp.Entities;
using ChessSchoolApp.Repositories;


var studentRepository = new SqlRepository<Student>(new ChessSchoolAppDbContext());
AddStudents(studentRepository);

WriteAllToConsole(studentRepository);
static void AddStudents(IRepository<Student> studentRepository)
{
    studentRepository.Add(new Student { FirstName = "Klaudia", LastName = "Kowalska" });
    studentRepository.Add(new Student { FirstName = "Piotr", LastName = "Nowak" });
    studentRepository.Add(new Student { FirstName = "BlaBla", LastName = "Bleble" });
    studentRepository.Save();
}


static void WriteAllToConsole(IReadRepository<IEntity> repository)
{
    var items = repository.GetAll();
    foreach (var item in items)
    {
        Console.WriteLine(item);
    }
}