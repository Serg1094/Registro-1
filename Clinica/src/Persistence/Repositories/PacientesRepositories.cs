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
    internal class PacientesRepository : IPacientes
    {
        private readonly ApplicationDbContext _context;

        public PacientesRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Pacientes>> GetPacientesAsync()
        {
            return await _context.ListaPacientes.ToListAsync();
        }

        public async Task<Pacientes?> GetPacienteByIdAsync(long id)
        {
            return await _context.ListaPacientes
                .FirstOrDefaultAsync(x => x.PacienteID == id);
        }
    }
}
