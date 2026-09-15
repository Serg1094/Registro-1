using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

public interface IGenericRepository<T> where T : class
{
    Task<List<T>> GetAllAsync();
    /* Agregar un nuevo registro */
    Task AddAsync(T entity);

    Task<List<T>> GetPageAsync(int TotalRegistro = 100);

    /* Buscar por ID*/
    Task<T?> GetByIdAsync(object id, CancellationToken cancellationToken = default);
    /* Buscar por filtro */
    Task<T?> GetOneAsync(Expression<Func<T, bool>> filter, bool asNoTracking = true, CancellationToken cancellationToken = default);

    Task<T> UpdateAsync(T entity);
    Task<T> DeleteAsync(T entity);

}