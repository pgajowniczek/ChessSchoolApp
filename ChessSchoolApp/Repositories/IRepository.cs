using ChessSchoolApp.Entities;

namespace ChessSchoolApp.Repositories
{
    public interface IRepository<T> where T : class, IEntity
    {
        IEnumerable<T> GetAll();

        T GetById(int Id);

        void Add(T item);

        void Remove(T item);

        void Save();
    }
}
