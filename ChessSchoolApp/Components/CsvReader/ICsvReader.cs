using ChessSchoolApp.Data.Entities;

public interface ICsvReader
{
    List<Student> ProcessStudents(string filePath);
    List<Ranking> ProcessRankings(string filePath);
}