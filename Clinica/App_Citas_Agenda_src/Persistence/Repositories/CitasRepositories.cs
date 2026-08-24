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
    internal class CitasRepository : ICitas
    {
        private readonly ApplicationDbContext _context;

        public CitasRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Cita>> GetCitasAsync()
        {
            return await _context.ListaCitas.ToListAsync();
        }

        public async Task<Cita?> GetCitaByIdAsync(long id)
        {
            return await _context.ListaCitas
                .FirstOrDefaultAsync(x => x.CitaID == id);
        }

        public async Task<List<Cita>> GetCitasAsync(int TotalRegistro = 100)
        {
            return await _context.ListaCitas.ToListAsync();
        }

        public async Task AddCitas(Cita citas)
        {
            _context.Add(citas);
            await _context.SaveChangesAsync();
        }
    }
}