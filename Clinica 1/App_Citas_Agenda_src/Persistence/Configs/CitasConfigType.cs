using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Persistence.Configs
{
    public class CitaConfigType : IEntityTypeConfiguration<Cita>
    {
        public void Configure(EntityTypeBuilder<Cita> builder)
        {
            builder.ToTable("Citas");
            builder.HasKey(x => x.CitaID);
            builder.Property(x => x.PacienteID).HasColumnName("PacienteID").IsRequired();
            builder.Property(x => x.MedicoID).HasColumnName("MedicoID").IsRequired();
            builder.Property(x => x.EspecialidadID).HasColumnName("EspecialidadID");
            builder.Property(x => x.ConsultorioID).HasColumnName("ConsultorioID");
            builder.Property(x => x.EstadoCitaID).HasColumnName("EstadoCitaID").IsRequired();
            builder.Property(x => x.FechaHoraInicio).HasColumnName("FechaHoraInicio").IsRequired();
            builder.Property(x => x.FechaHoraFin).HasColumnName("FechaHoraFin");
            builder.Property(x => x.Motivo).HasColumnName("Motivo");
            builder.Property(x => x.Observaciones).HasColumnName("Observaciones");
            builder.Property(x => x.UsuarioCreacionID).HasColumnName("UsuarioCreacionID");
            builder.Property(x => x.FechaCreacion).HasColumnName("FechaCreacion");
        }
    }
}
