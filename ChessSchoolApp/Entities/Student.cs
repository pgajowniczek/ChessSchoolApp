namespace ChessSchoolApp.Entities
{
    public class Student : EntityBase
    {
        private static int _idCounter = 0;
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Student() 
        {
            Id = ++_idCounter;
        }


public override string ToString() => $"Id: {Id}, Name: {FirstName}, Surname: {LastName}";


    }
}
