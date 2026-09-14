using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly DbContext _context;

    public GenericRepository(DbContext context)
    {
        _context = context;
    }
    public async Task<List<T>> GetAllAsync()
    {
        return await _context.Set<T>().ToListAsync();
    }
    /* Agregar un nuevo registro */
    public async Task AddAsync(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
        await _context.SaveChangesAsync();
        /*return entity*/
    }

    public async Task<List<T>> GetPageAsync(int TotalRegistro = 100)
    {
        return await _context.Set<T>().Take(TotalRegistro).ToListAsync();
    }

    public async Task<T?> GetByIdAsync(object id, CancellationToken cancellationToken = default)
    {
        return await _context.Set<T>().FindAsync(new object[] { id }, cancellationToken);
    }

    public async Task<bool> DeleteAsync(T entity)
    {
        
        if (entity == null)
            return false;

        _context.Set<T>().Remove(entity);
        var result = await _context.SaveChangesAsync();
        return result > 0;
    }

    public async Task<bool> UpdateAsync(T entity)
    {
        _context.Set<T>().Update(entity);
        var result = await _context.SaveChangesAsync();
        return result > 0;
    }

    public async Task<T?> GetOneAsync(Expression<Func<T, bool>> filter, bool asNoTracking = true, CancellationToken cancellationToken = default)
    {
        IQueryable<T> query = _context.Set<T>();
        if (asNoTracking)
        {
            query = query.AsNoTracking();
        }
        return await query.FirstOrDefaultAsync(filter, cancellationToken);
    }

}