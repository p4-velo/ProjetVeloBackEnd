using System.Linq.Expressions;

namespace ProjetVeloBackEnd.Services.Contracts;

public interface ICRUDService<T> where T : class
{
    Task<IList<T>> GetAll(Expression<Func<T, bool>> expression = null,
        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
        List<string> includes = null);

    Task<T?> Get(Expression<Func<T, bool>> expression, List<string> includes = null);
    Task Insert(T entity);
    Task InsertRange(IEnumerable<T> entities);
    Task Delete(params object?[]? keyValues);
    Task DeleteRange(IEnumerable<T> entities);
    Task Update(T entity);
}
