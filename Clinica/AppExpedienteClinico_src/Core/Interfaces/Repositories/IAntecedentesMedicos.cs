using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Domain.Models;

namespace Core.Interfaces.Repositories
{
    public interface IAntecedentesMedicos
    {
        Task<List<AntecedenteMedico>> GetAntecedentesMedicosAsync();

        Task<List<AntecedenteMedico>> GetAntecedentesMedicosAsync(int TotalRegistro = 100);
        Task AddAntecedenteMedico(AntecedenteMedico antecedenteMedico);
    }
}