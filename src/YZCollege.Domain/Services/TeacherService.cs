using YZCollege.Domain.Contracts.Repositories;
using YZCollege.Domain.Contracts.Services;
using YZCollege.Domain.Dtos.Request;
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
