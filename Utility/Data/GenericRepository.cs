using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace PC.Utility.Data;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly DbContext _db;
    private readonly DbSet<T> _dbSet;

    public GenericRepository(DbContext db)
    {
        _db = db;
        _dbSet = _db.Set<T>();
    }

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

    #region Get Data

    public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> f = null, string include = null)
    {
        IQueryable<T> query = _dbSet;
        if (f != null)
            query = query.Where(f);

        if (include != null)
            foreach (var i in include.Split(","))
                query = query.Include(i);

        return await query.ToListAsync();
    }

    public async Task<T?> GetAsync(Expression<Func<T, bool>> e, string include = null)
    {
        var query = _dbSet.Where(e);
        if (include != null)
            foreach (var i in include.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                query = query.Include(i);

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

    public async Task<T> ReturnCreateAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
        return entity;
    }

    #endregion

    // Other Operations
}