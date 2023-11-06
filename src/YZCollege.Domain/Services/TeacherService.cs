using System.Linq.Expressions;
using YZCollege.Domain.Contracts.Repositories;
using YZCollege.Domain.Contracts.Services;
using YZCollege.Domain.Dtos.Request;
using YZCollege.Domain.Dtos.Request.Query;
using YZCollege.Domain.Dtos.Response;
using YZCollege.Domain.Entities;

namespace YZCollege.Domain.Services
{
    public class TeacherService : Service<Teacher>, ITeacherService
    {
        public TeacherService(ITeacherRepository repository) : base(repository) { 
        }

        public async Task<bool> AddAsync(TeacherPostRequestDto data)
        {
            return await _repository.SaveAsync(new() { 
                Name = data.Name
            });
        }

        public async Task<List<TeacherResponseDto>> FindAllAsync(TeacherQueryDto filter)
        {
            Expression<Func<Teacher, bool>> query = course => true;

            if (filter.Id.HasValue)
                query = p => filter.Id == p.Id;
            else if (!string.IsNullOrWhiteSpace(filter?.Name))
                query = p => p.Name.Contains(filter.Name);

            var entities = await _repository.FindAllAsync(query);

            return entities.Select(teacher => new TeacherResponseDto()
            {
                Name = teacher.Name,
                Id = teacher.Id
            }).ToList();
        }

        public async Task<bool> AddAsync(TeacherPostV2RequestDto data)
        {
            return await _repository.SaveAsync(new()
            {
                Name = data.Name,
                FavoritePokemon = data.FavoritePokemon
            });
        }

        public async Task<bool> UpdateAsync(TeacherPutRequestDto data)
        {
            return await _repository.SaveAsync(new()
            {
                Id = data.Id,
                Name = data.Name
            });
        }
    }
}
