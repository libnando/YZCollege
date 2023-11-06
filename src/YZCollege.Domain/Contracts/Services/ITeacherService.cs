using YZCollege.Domain.Dtos.Request;
using YZCollege.Domain.Entities;

namespace YZCollege.Domain.Contracts.Services
{
    public interface ITeacherService : IService<Teacher>
    {
        Task<bool> AddAsync(TeacherPostRequestDto data);
        Task<bool> AddAsync(TeacherPostV2RequestDto data);
        Task<bool> UpdateAsync(TeacherPutRequestDto data);
    }
}
