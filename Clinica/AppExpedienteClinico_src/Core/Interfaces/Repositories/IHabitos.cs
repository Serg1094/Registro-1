using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Domain.Models;

namespace Core.Interfaces.Repositories
{
    public interface IHabitos
    {
        Task<List<Habito>> GetHabitosAsync();

        Task<List<Habito>> GetHabitosAsync(int TotalRegistro = 100);
        Task AddHabito(Habito habito);
    }
}