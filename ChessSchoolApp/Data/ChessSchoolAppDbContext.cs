using Microsoft.EntityFrameworkCore;
using ChessSchoolApp.Data.Entities;

namespace ChessSchoolApp.Data
{
    public class ChessSchoolAppDbContext : DbContext
    {
        public DbSet<Student> Students => Set<Student>();

        public DbSet<Trainer> Trainers => Set<Trainer>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseInMemoryDatabase("ChessSchoolAppDb");
        }

    }
}
