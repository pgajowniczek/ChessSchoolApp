using ChessSchoolApp.Entities;
using ChessSchoolApp.Repositories;

public class StudentProvider : IStudentProvider
{
    private readonly IRepository<Student> _studentRepository;
    public StudentProvider(IRepository<Student> studentRepository)
    {
        _studentRepository = studentRepository;
    }
    public List<Student> OrderBySurname()
    {
        var students = _studentRepository.GetAll();
        var ordered = students.OrderBy(x => x.LastName).ThenBy(x => x.FirstName).ToList();
        return ordered;
    }
}
