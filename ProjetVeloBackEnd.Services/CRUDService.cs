using ProjetVeloBackEnd.DAL.Contracts;
using ProjetVeloBackEnd.Services.Contracts;
using System.Linq.Expressions;

namespace ProjetVeloBackEnd.Services;

public class CRUDService<T> : ICRUDService<T> where T : class
{
    private readonly IRepository<T> _repository;

    public CRUDService(IRepository<T> repository)
    {
        _repository = repository;
    }

    public async Task Delete(params object?[]? keyValues)
    {
        await _repository.Delete(keyValues);
        await _repository.Save();
    }

    public async Task DeleteRange(IEnumerable<T> entities)
    {
        _repository.DeleteRange(entities);
        await _repository.Save();
    }

    public async Task<T?> Get(Expression<Func<T, bool>> expression, List<string> includes = null)
    {
        return await _repository.Get(expression, includes);
    }

    public async Task<IList<T>> GetAll(Expression<Func<T, bool>> expression = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, List<string> includes = null)
    {
        return await _repository.GetAll(expression, orderBy, includes);
    }

    public async Task Insert(T entity)
    {
        await _repository.Insert(entity);
        await _repository.Save();
    }

    public async Task InsertRange(IEnumerable<T> entities)
    {
        await _repository.InsertRange(entities);
        await _repository.Save();
    }

    public async Task Update(T entity)
    {
        _repository.Update(entity);
        await _repository.Save();
    }
}
