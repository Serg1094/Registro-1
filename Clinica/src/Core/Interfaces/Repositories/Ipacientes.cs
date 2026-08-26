using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Repositories
{
    public interface IPacientes
    {
        Task<List<Pacientes>> GetPacientesAsync();
    
        Task<List<Pacientes>> GetPacientesAsync(int TotalRegistro = 100);

        Task AddPacientes(Pacientes paciente);
    }
}
