using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Repositories
{
    public interface IMedicos
    {
        Task<List<Medicos>> GetMedicosAsync();
        Task<Medicos?> GetMedicoByIdAsync(int id);
    }
}
