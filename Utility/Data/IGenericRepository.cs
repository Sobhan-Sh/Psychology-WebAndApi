using System.Linq.Expressions;


namespace Utility.Data;

public interface IGenericRepository<T> where T : class
{
    #region Get

    Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> f = null, string include = null);
    Task<T?> GetAsync(Expression<Func<T, bool>> e, string include = null);

    #endregion

    #region Create

    Task CreateRangeAsync(List<T> entities);
    Task CreateAsync(T entity);

    #endregion

    #region Delete

    Task DeleteAsync(T entity);

    #endregion

    // Other Operations
    Task<bool> IsExistAsync(Expression<Func<T, bool>> e);

    Task SaveAsync();
    // Other Operations
}