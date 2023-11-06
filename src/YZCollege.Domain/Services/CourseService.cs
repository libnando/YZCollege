using System.Linq.Expressions;
using YZCollege.Domain.Contracts.Repositories;
using YZCollege.Domain.Contracts.Services;
using YZCollege.Domain.Dtos.Request;
using YZCollege.Domain.Dtos.Request.Query;
using YZCollege.Domain.Dtos.Response;
using YZCollege.Domain.Entities;

namespace YZCollege.Domain.Services
{
    public class CourseService : Service<Course>, ICourseService
    {
        public CourseService(ICourseRepository repository) : base(repository) { 
        }

        public async Task<bool> AddAsync(CoursePostRequestDto data)
        {
            return await _repository.SaveAsync(new()
            {
                Name = data.Name,
                Description = data.Description,
                Duration = data.Duration,
                TeacherId = data.TeacherId
            });
        }

        public async Task<List<CourseResponseDto>> FindAllAsync(CourseQueryDto filter)
        {
            Expression<Func<Course, bool>> query = course => true;

            if (filter.Id.HasValue)
                query = p => filter.Id == p.Id;
            else if (!string.IsNullOrWhiteSpace(filter?.Name))
                query = p => p.Name.Contains(filter.Name);

            var entities = await _repository.FindAllAsync(query);

            return entities.Select(course => new CourseResponseDto()
            {
                Name = course.Name,
                Id = course.Id
            }).ToList();
        }
    }
}
