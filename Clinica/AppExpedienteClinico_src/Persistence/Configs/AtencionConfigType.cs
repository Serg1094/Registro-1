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
    public class AtencionConfigType : IEntityTypeConfiguration<Atenciones>
    {
        public void Configure(EntityTypeBuilder<Atenciones> builder)
        {
            builder.ToTable("Atenciones");
            builder.HasKey(x => x.AtencionID);
            builder.Property(builder => builder.PacienteID).IsRequired();
            builder.Property(builder => builder.MedicoID).IsRequired();
            builder.Property(builder => builder.CitaID).IsRequired();
            builder.Property(builder => builder.ExpedienteID).IsRequired();
            builder.Property(builder => builder.FechaInicio).IsRequired();
            builder.Property(builder => builder.FechaFin).IsRequired();
            builder.Property(builder => builder.MotivoConsulta).IsRequired();
            builder.Property(builder => builder.EnfermedadActual).HasMaxLength(500);
            builder.Property(builder => builder.ExploracionFisica).HasMaxLength(500);
            builder.Property(builder => builder.Observaciones).HasMaxLength(500);
            builder.Property(builder => builder.Estado).IsRequired();
            builder.Property(builder => builder.UsuarioCreacionID).IsRequired();
        }
    }
}
