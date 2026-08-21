using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Domain.Models;

namespace Core.Interfaces.Repositories
{
    public interface IConsultorios
    {
        Task<List<Consultorio>> GetConsultoriosAsync();
        Task<Consultorio?> GetConsultorioByIdAsync(int id);
    }
}
