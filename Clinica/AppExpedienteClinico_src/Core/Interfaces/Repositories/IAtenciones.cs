using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Domain.Models;

namespace Core.Interfaces.Repositories
{
    public interface IAtenciones
    {
        Task<List<Atenciones>> GetAtencionesAsync();

        Task<List<Atenciones>> GetAtencionesAsync(int TotalRegistro = 100);
        Task AddAtenciones(Atenciones atencion);
    }
}