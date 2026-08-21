using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Domain.Models;

namespace Core.Interfaces.Repositories
{
    public interface ICitas
    {
        Task<List<Cita>> GetCitasAsync();
        Task<Cita?> GetCitaByIdAsync(long id);
    }
}
