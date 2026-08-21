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
    internal class TurnosRepository : ITurnos
    {
        private readonly ApplicationDbContext _context;

        public TurnosRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Turno>> GetTurnosAsync()
        {
            return await _context.ListaTurnos.ToListAsync();
        }

        public async Task<Turno?> GetTurnoByIdAsync(long id)
        {
            return await _context.ListaTurnos
                .FirstOrDefaultAsync(x => x.TurnoID == id);
        }
    }
}