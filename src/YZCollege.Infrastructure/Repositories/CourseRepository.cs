using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using YZCollege.Domain.Contracts.Repositories;
using YZCollege.Domain.Entities;
using YZCollege.Infrastructure.Context;

namespace YZCollege.Infrastructure.Repositories
{
    public class CourseRepository : Repository<Course>, ICourseRepository
    {
        public CourseRepository(SqlContext context) : base(context)
        {
        }

        public override Task<List<Course>> FindAllAsync(Expression<Func<Course, bool>> where) => _context.Set<Course>().Where(where).Include(c => c.Teacher).ToListAsync();
    }
}
