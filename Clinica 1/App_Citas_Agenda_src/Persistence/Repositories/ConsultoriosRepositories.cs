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
    internal class ConsultoriosRepository : IConsultorios
    {
        private readonly ApplicationDbContext _context;

        public ConsultoriosRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Consultorio>> GetConsultoriosAsync()
        {
            return await _context.ListaConsultorios.ToListAsync();
        }

        public async Task<Consultorio?> GetConsultorioByIdAsync(int id)
        {
            return await _context.ListaConsultorios
                .FirstOrDefaultAsync(x => x.ConsultorioID == id);
        }
    }
}