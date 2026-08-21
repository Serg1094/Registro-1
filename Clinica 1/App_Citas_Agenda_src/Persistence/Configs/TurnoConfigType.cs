using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configs
{
    public class TurnoConfigType : IEntityTypeConfiguration<Turno>
    {
        public void Configure(EntityTypeBuilder<Turno> builder)
        {
            builder.ToTable("Turnos");
            builder.HasKey(x => x.TurnoID);
            builder.Property(x => x.CitaID).HasColumnName("CitaID");
            builder.Property(x => x.PacienteID).HasColumnName("PacienteID").IsRequired();
            builder.Property(x => x.SucursalID).HasColumnName("SucursalID").IsRequired();
            builder.Property(x => x.NumeroTurno).HasColumnName("NumeroTurno").IsRequired();
            builder.Property(x => x.FechaTurno).HasColumnName("FechaTurno").IsRequired();
            builder.Property(x => x.Prioridad).HasColumnName("Prioridad");
            builder.Property(x => x.Estado).HasColumnName("Estado").IsRequired();
            builder.Property(x => x.FechaIngreso).HasColumnName("FechaIngreso");
            builder.Property(x => x.FechaLlamado).HasColumnName("FechaLlamado");
            builder.Property(x => x.FechaAtencion).HasColumnName("FechaAtencion");
            builder.Property(x => x.FechaFinalizacion).HasColumnName("FechaFinalizacion");
        }
    }
}