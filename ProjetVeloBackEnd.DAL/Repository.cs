using ProjetVeloBackEnd.DAL.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ProjetVeloBackEnd.DAL;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly AppDbContext _context;
    private readonly DbSet<T> _dbSet;

    public Repository(AppDbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public async Task Delete(params object?[]? keyValues)
    {
        // Utilisez le DbSet du DbContext pour récupérer l'entité avec les valeurs de clé primaire spécifiées.
        // Le mot-clé params permet à l'appelant de passer un nombre variable d'arguments.
        // La syntaxe ?[]? indique que le paramètre keyValues est nullable, ce qui signifie qu'il peut être omis.
        var entity = await _dbSet.FindAsync(keyValues);

        if (entity is not null)
            _dbSet.Remove(entity);
    }

    public void DeleteRange(IEnumerable<T> entities)
    {
        _dbSet.RemoveRange(entities);
    }

    public async Task<T?> Get(Expression<Func<T, bool>> expression, List<string> includes = null)
    {
        IQueryable<T> query = _dbSet;
        if (includes is not null)
            query = includes.Aggregate(query, (current, include) => current.Include(include));

        return await query.AsNoTracking().FirstOrDefaultAsync(expression);
    }

    public async Task<IList<T>> GetAll(Expression<Func<T, bool>> expression = null, 
                                Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, 
                                List<string> includes = null)
    {
        IQueryable<T> query = _dbSet;

        // Si l'appelant a spécifié une condition pour la requête, utilisez la méthode Where
        // pour filtrer la requête en utilisant l'expression spécifiée. Cela ajoutera une clause WHERE
        // à la requête qui applique la condition spécifiée.
        if (expression is not null)
            query = query.Where(expression);

        if (includes is not null)
            query = includes.Aggregate(query, (current, include) => current.Include(include));

        // Si l'appelant a spécifié un ordre pour la requête, utilisez la fonction spécifiée
        // pour ordonner la requête. Cela ajoutera une clause ORDER BY à la requête qui appliquera
        // l'ordre spécifié.
        if (orderBy is not null)
            query = orderBy(query);

        return await query.AsNoTracking().ToListAsync();
    }

    public async Task Insert(T entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public async Task InsertRange(IEnumerable<T> entities)
    {
        await _dbSet.AddRangeAsync(entities);
    }

    public void Update(T entity)
    {
        _dbSet.Update(entity);
    }

    public async Task Save()
    {
        await _context.SaveChangesAsync();
    }
}
