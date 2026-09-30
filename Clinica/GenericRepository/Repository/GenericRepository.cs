using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
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
        await _context.SaveChangesAsync();


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
            await _context.SaveChangesAsync();
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
        await _context.SaveChangesAsync();
        return await Task.FromResult(entity);
    }

    public async Task<PagedResult<T>> GetPagedAsync(int pageNumber,int pageSize,Expression<Func<T, bool>>? filter = null,Func<IQueryable<T>, IOrderedQueryable<T>>? 
        orderBy = null,bool asNoTracking = true, CancellationToken cancellationToken = default)
    {
        if (pageNumber < 1) throw new ArgumentOutOfRangeException(nameof(pageNumber), "pageNumber debe ser 1 o mayor.");
        if (pageSize < 1) throw new ArgumentOutOfRangeException(nameof(pageSize), "pageSize debe ser 1 o mayor.");

        IQueryable<T> query = asNoTracking ? _dbSet.AsNoTracking() : _dbSet;

        if (filter != null)
            query = query.Where(filter);

        int totalRecords = await query.CountAsync(cancellationToken);

        query = orderBy != null ? orderBy(query) : query;
        query = query.Skip((pageNumber - 1) * pageSize).Take(pageSize);

        var data = await query.ToListAsync(cancellationToken);

        return new PagedResult<T>
        {
            Data = data,
            TotalRecords = totalRecords,
            PageSize = pageSize,
            CurrentPage = pageNumber
        };
    }

    public async Task<PagedResult<T>> GetPagedAsync(
       int pageNumber,
       int pageSize,
       Expression<Func<T, bool>>? filter = null,
       string? orderBy = null,
       bool asNoTracking = true,
       CancellationToken cancellationToken = default)
    {
        if (pageNumber < 1) throw new ArgumentOutOfRangeException(nameof(pageNumber), "pageNumber debe ser 1 o mayor.");
        if (pageSize < 1) throw new ArgumentOutOfRangeException(nameof(pageSize), "pageSize debe ser 1 o mayor.");

        IQueryable<T> query = asNoTracking ? _dbSet.AsNoTracking() : _dbSet;

        if (filter != null)
            query = query.Where(filter);

        int totalRecords = await query.CountAsync(cancellationToken);

        // ORDENAMIENTO DINÁMICO: recibe algo como "FechaHoraInicio desc" o "MedicoID asc"
        if (!string.IsNullOrWhiteSpace(orderBy))
            query = query.OrderBy(orderBy);   // extensión de System.Linq.Dynamic.Core

        query = query.Skip((pageNumber - 1) * pageSize).Take(pageSize);

        var data = await query.ToListAsync(cancellationToken);

        return new PagedResult<T>
        {
            Data = data,
            TotalRecords = totalRecords,
            PageSize = pageSize,
            CurrentPage = pageNumber
        };
    }

    // --- NUEVO: guardar una lista completa de entidades de un jalón ---
    public async Task AddRangeAsync(List<T> entities)
    {
        ArgumentNullException.ThrowIfNull(entities);
        if (entities.Count == 0)
            return;

        await _dbSet.AddRangeAsync(entities);
        await _context.SaveChangesAsync();
    }
}
