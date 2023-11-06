using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using YZCollege.Domain.Contracts.Repositories;
using YZCollege.Domain.Entities;
using YZCollege.Infrastructure.Context;

namespace YZCollege.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        protected readonly SqlContext _context;

        public Repository(SqlContext context) => _context = context;

        public virtual Task<List<T>> FindAllAsync(Expression<Func<T, bool>> where) => _context.Set<T>().Where(where).ToListAsync();

        public virtual async Task<bool> DeleteAsync(int id)
        {
            return (await _context.Set<T>().Where(e => e.Id == id).ExecuteDeleteAsync()) > 0;
        }

        public virtual async Task<bool> SaveAsync(T entity)
        {
            if (entity.Id > 0)
                _context.Update(entity);
            else
                await _context.AddAsync(entity);

            return (await _context.SaveChangesAsync()) > 0;
        }

    }
}
