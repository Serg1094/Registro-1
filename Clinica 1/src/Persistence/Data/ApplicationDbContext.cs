using Core.Interfaces.Repositories;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
namespace Persistence.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Pacientes> ListaPacientes { get; set; }
        public DbSet<Contacto_Emergencia> ContactosEmergencia { get; set; }
        public DbSet<Medicos> ListaMedicos { get; set; }
        public DbSet<Especialidades> Especialidades { get; set; }
        public DbSet<Medico_Especialidad> MedicosEspecialidades { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}