using ChessSchoolApp.Data.Entities;

public interface IStudentProvider
{
    List<Student> OrderBySurname();
}
