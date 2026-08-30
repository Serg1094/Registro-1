using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Domain.Models;

namespace Core.Interfaces.Repositories
{
    public interface ISignosVitales
    {
        Task<List<SignoVital>> GetSignosVitalesAsync();

        Task<List<SignoVital>> GetSignosVitalesAsync(int TotalRegistro = 100);
        Task AddSignoVital(SignoVital signoVital);
    }
}