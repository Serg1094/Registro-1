using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IGenericRepository<T> where T : class
{
    Task<List<T>> GetAllAsync();

    Task AddAsync(T entity);

    Task<List<T>> GetPageAsync(int TotalRegistro = 100);

    Task<T?> GetByIdAsync(int id);
    
}