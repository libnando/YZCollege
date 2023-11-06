using YZCollege.Domain.Contracts.Repositories;
using YZCollege.Domain.Entities;
using YZCollege.Infrastructure.Context;

namespace YZCollege.Infrastructure.Repositories
{
    public class TeacherRepository : Repository<Teacher>, ITeacherRepository
    {
        public TeacherRepository(SqlContext context) : base(context)
        {
        }
    }
}
