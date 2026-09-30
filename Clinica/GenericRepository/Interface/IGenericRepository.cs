using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

public interface IGenericRepository<T> where T : class
{
    Task<List<T>> GetAllAsync();
    Task AddAsync(T entity);
    Task<List<T>> GetPageAsync(int TotalRegistro = 100);
    Task<T?> GetByIdAsync(object id, CancellationToken cancellationToken = default);
    Task<T?> GetOneAsync(Expression<Func<T, bool>> filter, bool asNoTracking = true, CancellationToken cancellationToken = default);
    Task<T> UpdateAsync(T entity);
    Task<T> DeleteAsync(T entity);

    Task<PagedResult<T>> GetPagedAsync(
        int pageNumber,
        int pageSize,
        Expression<Func<T, bool>>? filter = null,
        string? orderBy = null,                 // <-- CAMBIÓ: antes Func<...>, ahora string dinámico
        bool asNoTracking = true,
        CancellationToken cancellationToken = default);

    // --- NUEVO: guardar una lista completa de una vez ---
    Task AddRangeAsync(List<T> entities);
}