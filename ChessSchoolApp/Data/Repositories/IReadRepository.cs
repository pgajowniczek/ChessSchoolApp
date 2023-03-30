using ChessSchoolApp.Data.Entities;

namespace ChessSchoolApp.Repositories
{
    public interface IReadRepository <out T> where T : class, IEntity
    {
        
        IEnumerable<T> GetAll();

        T GetById(int Id);
    }
}
