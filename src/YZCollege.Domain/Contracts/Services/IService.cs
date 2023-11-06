using YZCollege.Domain.Entities;

namespace YZCollege.Domain.Contracts.Services
{
    public interface IService<T> where T : Entity
    {
        Task<bool> DeleteAsync(int id);
    }
}
