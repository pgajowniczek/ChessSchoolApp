using ChessSchoolApp.Data.Entities;

public class CsvReader : ICsvReader
{
    public List<Ranking> ProcessRankings(string filePath)
    {
        if (!File.Exists(filePath))
        {
            return new List<Ranking>();
        }

        var rankings =
            File.ReadAllLines(filePath)
            .Skip(1)
            .Where(x => x.Length > 0)
            .Select(x =>
            {
                var columns = x.Split(',');
                return new Ranking()
                {
                    StudentId = int.Parse(columns[0]),
                    MatchesPlayed = int.Parse(columns[1]),
                    Wins = int.Parse(columns[2]),
                    Losses = int.Parse(columns[3]),
                    Draws = int.Parse(columns[4]),
                    Points = double.Parse(columns[5])
                };
            }
            );

        return rankings.ToList();
    }

    public List<Student> ProcessStudents(string filePath)
    {
        if (!File.Exists(filePath))
        {
            return new List<Student>();
        }

        var students = File.ReadAllLines(filePath)
            .Skip(1)
            .Where(x => x.Length > 0)
            .Select(x =>
            {
                var columns = x.Split(",");

                return new Student()
                {
                    Id = int.Parse(columns[0]),
                    FirstName = columns[1],
                    LastName = columns[2]
                };
            });
        return students.ToList();
    }
}

