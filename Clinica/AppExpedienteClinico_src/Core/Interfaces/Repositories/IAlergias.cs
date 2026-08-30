using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Domain.Models;

namespace Core.Interfaces.Repositories
{
    public interface IAlergias
    {
        Task<List<Alergia>> GetAlergiasAsync();

        Task<List<Alergia>> GetAlergiasAsync(int TotalRegistro = 100);
        Task AddAlergia(Alergia alergia);
    }
}