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
    internal class MedicosRepository : IMedicos
    {
        private readonly ApplicationDbContext _context;

        public MedicosRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Medicos>> GetMedicosAsync()
        {
            return await _context.ListaMedicos.ToListAsync();
        }

        public async Task<Medicos?> GetMedicoByIdAsync(int id)
        {
            return await _context.ListaMedicos
                .FirstOrDefaultAsync(x => x.MedicoID == id);
        }
    }
}