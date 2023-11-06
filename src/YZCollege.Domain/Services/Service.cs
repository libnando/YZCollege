using YZCollege.Domain.Contracts.Repositories;
using YZCollege.Domain.Contracts.Services;
using YZCollege.Domain.Entities;

namespace YZCollege.Domain.Services
{
    public abstract class Service<T> : IService<T> where T : Entity
    {
        protected readonly IRepository<T> _repository;

        public Service(IRepository<T> repository)
        {
            _repository = repository;
        }

        public virtual Task<bool> DeleteAsync(int id) => _repository.DeleteAsync(id);
    }
}
