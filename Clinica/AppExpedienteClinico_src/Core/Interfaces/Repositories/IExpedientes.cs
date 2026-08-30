using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Domain.Models;

namespace Core.Interfaces.Repositories
{
    public interface IExpedientes
    {
        Task<List<ExpedienteClinico>> GetExpedientesAsync();

        Task<List<ExpedienteClinico>> GetExpedientesAsync(int TotalRegistro = 100);
        Task AddExpediente(ExpedienteClinico expediente);
    }
}