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
    internal class SignosVitalesRepository : ISignosVitales
    {
        private readonly ApplicationDbContext _context;

        public SignosVitalesRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<SignoVital>> GetSignosVitalesAsync()
        {
            return await _context.ListaSignosVitales.Take(100).ToListAsync();
        }


        public async Task<List<SignoVital>> GetSignosVitalesAsync(int TotalRegistro = 100)
        {
            return await _context.ListaSignosVitales.Take(TotalRegistro).ToListAsync();
        }

        public async Task AddSignoVital(SignoVital signoVital)
        {
            _context.Add(signoVital);
            await _context.SaveChangesAsync();
        }
    }
}