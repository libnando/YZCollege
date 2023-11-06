using YZCollege.Domain.Dtos.Request;
using YZCollege.Domain.Dtos.Request.Query;
using YZCollege.Domain.Dtos.Response;
using YZCollege.Domain.Entities;

namespace YZCollege.Domain.Contracts.Services
{
    public interface ITeacherService : IService<Teacher>
    {
        Task<List<TeacherResponseDto>> FindAllAsync(TeacherQueryDto filter);
        Task<bool> AddAsync(TeacherPostRequestDto data);
        Task<bool> AddAsync(TeacherPostV2RequestDto data);
        Task<bool> UpdateAsync(TeacherPutRequestDto data);
    }
}
