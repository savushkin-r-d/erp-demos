using System.Linq.Expressions;
using Domain;

namespace DataAccess.EFCore.Interfaces
{
    public interface IGenericRepository<T> where T : EntityBase
    {
        Task<T> GetByFId(int id);

        Task<IEnumerable<T>> GetAll(bool includeDeleted = false);

        Task<IEnumerable<T>> Find(Expression<Func<T, bool>> func);

        Task<T> Add(T entity);

        void Remove(T entity);

        void Update(T entity);
    }
}
