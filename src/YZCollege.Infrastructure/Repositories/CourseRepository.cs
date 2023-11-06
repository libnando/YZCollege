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
    }
}
