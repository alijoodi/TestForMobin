using Models.EntityBase;
using System.Linq.Expressions;

namespace Repositories
{
    public interface IApplicationRepository<TEntity> where TEntity : EntityBase
    {
        Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate, params string[] include);
        Task<List<TEntity>> ToTaskPaged(Expression<Func<TEntity, bool>> predicate, int pageNumber, int pageSize);
        Task<List<TEntity>> GetList(Expression<Func<TEntity, bool>> predicate);

        Task AddAsync(TEntity entity);
        Task AddRangeAsync(IEnumerable<TEntity> entities);
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
        void Update(TEntity entity);
        Task<bool> SaveAllAsync();

    }
}