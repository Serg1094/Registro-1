using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Domain.Models;

namespace Core.Interfaces.Repositories
{
    public interface IAntecedentesFamiliares
    {
        Task<List<AntecedenteFamiliar>> GetAntecedentesFamiliaresAsync();

        Task<List<AntecedenteFamiliar>> GetAntecedentesFamiliaresAsync(int TotalRegistro = 100);
        Task AddAntecedenteFamiliar(AntecedenteFamiliar antecedenteFamiliar);
    }
}