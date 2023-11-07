using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Utility.Data
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DbContext _db;
        private DbSet<T> _dbSet;

        public GenericRepository(DbContext db)
        {
            _db = db;
            _dbSet = _db.Set<T>();
        }

        #region Get Data

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> f = null, string include = null)
        {
            IQueryable<T> query = _dbSet;
            if (f != null)
                query = query.Where(f);

            if (include != null)
            {
                foreach (var i in include.Split(","))
                {
                    query = query.Include(i);
                }
            }

            return await query.ToListAsync();
        }

        public async Task<T?> GetAsync(Expression<Func<T, bool>> e, string include = null)
        {
            IQueryable<T> query = _dbSet.Where(e);
            if (include != null)
                foreach (var i in include.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(i);
                }

            return await query.FirstOrDefaultAsync();
        }

        #endregion

        #region Create Data

        public async Task CreateRangeAsync(List<T> entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }

        public async Task CreateAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        #endregion

        #region Delete Data

        public async Task DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
        }

        #endregion


        // Other Operations
        public async Task<bool> IsExistAsync(Expression<Func<T, bool>> e)
        {
            return await _dbSet.AnyAsync(e);
        }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }
        // Other Operations
    }
}
