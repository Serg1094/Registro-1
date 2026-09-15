using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly DbContext _context;
    private readonly DbSet<T> _dbSet;
    public GenericRepository(DbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    /* Agregar un nuevo registro */
    public async Task AddAsync(T entity)
    {
        ArgumentNullException.ThrowIfNull(entity);
        await _dbSet.AddAsync(entity);
        
    }

    /* Buscar por ID*/
    public async Task<T?> GetByIdAsync(object id, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNullOrEmpty(nameof(id));
        return await _dbSet.FindAsync(new[] { id }, cancellationToken);
    }

    /* Obtener todos los registros */
    public async Task<List<T>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    /* Obtener registros paginados */
    public async Task<List<T>> GetPageAsync(int TotalRegistro = 100)
    {
        return await _dbSet.Take(TotalRegistro).ToListAsync();
    }
        
    /* Obtener un registro por filtro */
    public async Task<T?> GetOneAsync(Expression<Func<T, bool>> filter, bool asNoTracking = true, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(filter);
        IQueryable<T> query = _dbSet;
        return await query.FirstOrDefaultAsync(filter, cancellationToken);
    }

    /* Eliminar un registro */
    public async Task<T> DeleteAsync(T entity)
    {
        ArgumentNullException.ThrowIfNull(entity);
        
        {
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }
            _dbSet.Remove(entity);
            return await Task.FromResult(entity);
        }
    }

    /* Actualizar un registro */
    public async Task<T> UpdateAsync(T entity)
    {
        ArgumentNullException.ThrowIfNull(entity);
        if (_context.Entry(entity).State == EntityState.Detached)
        {
            _dbSet.Attach(entity);
        }
        _context.Entry(entity).State = EntityState.Modified;
        return await Task.FromResult(entity);
    }

}