using YZCollege.Domain.Dtos.Request;
using YZCollege.Domain.Dtos.Request.Query;
using YZCollege.Domain.Dtos.Response;
using YZCollege.Domain.Entities;

namespace YZCollege.Domain.Contracts.Services
{
    public interface ICourseService : IService<Course>
    {
        Task<List<CourseResponseDto>> FindAllAsync(CourseQueryDto filter);
        Task<bool> AddAsync(CoursePostRequestDto data);
    }
}
