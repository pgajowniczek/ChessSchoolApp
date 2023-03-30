namespace ChessSchoolApp.Data.Entities
{
    public class Student : EntityBase, INameable
    {
        private static int _idCounter = 0;
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Ranking StudentRanking { get; set; }

        public Student()
        {
            Id = ++_idCounter;
            StudentRanking = new Ranking { StudentId = Id, MatchesPlayed = 0, Wins = 0, Draws = 0, Points = 1100 };
        }


        public override string ToString() => $"Id: {Id}, Name: {FirstName}, Surname: {LastName}";


    }
}
