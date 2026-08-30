using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Persistence.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<ExpedienteClinico> ListaExpedientes { get; set; }
        public DbSet<AntecedenteMedico> ListaAntecedentesMedicos { get; set; }
        public DbSet<AntecedenteFamiliar> ListaAntecedentesFamiliares { get; set; }
        public DbSet<Alergia> ListaAlergias { get; set; }
        public DbSet<Habito> ListaHabitos { get; set; }
        public DbSet<Atenciones> ListaAtenciones { get; set; }
        public DbSet<SignoVital> ListaSignosVitales { get; set; }
        public DbSet<Diagnostico> ListaDiagnosticos { get; set; }
        public DbSet<AtencionDiagnostico> ListaAtencionDiagnosticos { get; set; }
        public DbSet<Sintoma> ListaSintomas { get; set; }
        public DbSet<AtencionSintoma> ListaAtencionSintomas { get; set; }

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