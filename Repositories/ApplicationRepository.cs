
using Microsoft.EntityFrameworkCore;
using Models.Context;
using Models.EntityBase;
using System.Linq.Expressions;

namespace Repositories
{
    public class ApplicationRepository<TEntity> : IApplicationRepository<TEntity> where TEntity : EntityBase
    {
        private readonly ApplicationContext _context;

        public ApplicationRepository(ApplicationContext context)
        {
            this._context = context;
        }
        public async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate) => await _context.Set<TEntity>().AnyAsync(predicate);
        public async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate) => await _context.Set<TEntity>().Where(predicate).FirstOrDefaultAsync();

        public async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate, params string[] include)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>().Where(predicate);
            foreach (var item in include)
            {
                query = query.Include(item);
            }
            return await query.FirstOrDefaultAsync();
        }

        public async Task AddAsync(TEntity entity) => await _context.Set<TEntity>().AddAsync(entity);
        public async Task AddRangeAsync(IEnumerable<TEntity> entities) => await _context.Set<TEntity>().AddRangeAsync(entities);

        public void Remove(TEntity entity) => _context.Set<TEntity>().Remove(entity);

        public void RemoveRange(IEnumerable<TEntity> entities) => _context.Set<TEntity>().RemoveRange(entities);

        public void Update(TEntity entity) => _context.Set<TEntity>().Update(entity);

        public void UpdateRange(IEnumerable<TEntity> entities) => _context.Set<TEntity>().UpdateRange(entities);

        public async Task<List<TEntity>> ToTaskPaged(Expression<Func<TEntity, bool>> predicate, int pageNumber, int pageSize) =>

            await _context.Set<TEntity>().Where(predicate)
                .Skip(pageSize * (pageNumber - 1))
                .Take(pageSize)
                .ToListAsync();


        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<TEntity>> GetList(Expression<Func<TEntity, bool>> predicate) => await _context.Set<TEntity>().Where(predicate).ToListAsync();

    }
}
