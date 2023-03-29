using ChessSchoolApp.Entities;

namespace ChessSchoolApp.Repositories
{
    public interface IRepository<T> : IReadRepository<T>, IWriteRepository<T> where T : class, IEntity
    {
        event EventHandler<T> ItemAdded;
        event EventHandler<T> ItemRemoved;
    }
}
