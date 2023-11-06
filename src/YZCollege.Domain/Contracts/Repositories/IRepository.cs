using System.Linq.Expressions;
using YZCollege.Domain.Entities;

namespace YZCollege.Domain.Contracts.Repositories
{
    public interface IRepository<T> where T : Entity
    {
        Task<bool> SaveAsync(T entity);
        Task<bool> DeleteAsync(int id);
        Task<List<T>> FindAllAsync(Expression<Func<T, bool>> where);
    }
}
