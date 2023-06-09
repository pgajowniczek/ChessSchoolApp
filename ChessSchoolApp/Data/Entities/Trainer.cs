﻿namespace ChessSchoolApp.Data.Entities
{
    public class Trainer : EntityBase, INameable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        private static int _idCounter = 0;

        public Trainer()
        {
            Id = ++_idCounter;
        }

        public override string ToString() => $"Id: {Id}, Name: {FirstName}, Surname: {LastName} (coach)";
    }
}
