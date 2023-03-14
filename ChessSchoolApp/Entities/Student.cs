namespace ChessSchoolApp.Entities
{
    public class Student : EntityBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public override string ToString() => $"Id: {Id}, Name: {FirstName}, Surname: {LastName}";
    }
}
