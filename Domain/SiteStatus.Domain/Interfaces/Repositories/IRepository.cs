using SiteStatus.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SiteStatus.Domain.Interfaces.Repositories
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        void Add(TEntity entity);
        Task<bool> SaveChangesAsync();
        Task<IEnumerable<TEntity>> GetAllAsync();
    }
}