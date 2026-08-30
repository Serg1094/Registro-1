using Core.Interfaces.Repositories;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    internal class AtencionesRepository : IAtenciones
    {
        private readonly ApplicationDbContext _context;

        public AtencionesRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Atenciones>> GetAtencionesAsync()
        {
            return await _context.ListaAtenciones.Take(100).ToListAsync();
        }


        public async Task<List<Atenciones>> GetAtencionesAsync(int TotalRegistro = 100)
        {
            return await _context.ListaAtenciones.Take(TotalRegistro).ToListAsync();
        }

        public async Task AddAtenciones(Atenciones atencion)
        {
            _context.Add(atencion);
            await _context.SaveChangesAsync();
        }
    }
}