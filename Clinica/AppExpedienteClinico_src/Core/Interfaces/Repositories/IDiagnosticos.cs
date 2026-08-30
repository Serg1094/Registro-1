using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Domain.Models;

namespace Core.Interfaces.Repositories
{
    public interface IDiagnosticos
    {
        Task<List<Diagnostico>> GetDiagnosticoAsync();

        Task<List<Diagnostico>> GetDiagnosticoAsync(int TotalRegistro = 100);
        Task AddDiagnostico(Diagnostico diagnosticos);
    }
}