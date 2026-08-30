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
    internal class DiagnosticosRepository : IDiagnosticos
    {
        private readonly ApplicationDbContext _context;

        public DiagnosticosRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Diagnostico>> GetDiagnosticoAsync()
        {
            return await _context.ListaDiagnosticos.Take(100).ToListAsync();
        }


        public async Task<List<Diagnostico>> GetDiagnosticoAsync(int TotalRegistro = 100)
        {
            return await _context.ListaDiagnosticos.Take(TotalRegistro).ToListAsync();
        }

        public async Task AddDiagnostico(Diagnostico diagnostico)
        {
            _context.Add(diagnostico);
            await _context.SaveChangesAsync();
        }
    }
}