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
    internal class ExpedientesRepository : IExpedientes
    {
        private readonly ApplicationDbContext _context;

        public ExpedientesRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ExpedienteClinico>> GetExpedientesAsync()
        {
            return await _context.ListaExpedientes.Take(100).ToListAsync();
        }


        public async Task<List<ExpedienteClinico>> GetExpedientesAsync(int TotalRegistro = 100)
        {
            return await _context.ListaExpedientes.Take(TotalRegistro).ToListAsync();
        }

        public async Task AddExpediente(ExpedienteClinico expediente)
        {
            _context.Add(expediente);
            await _context.SaveChangesAsync();
        }
    }
}