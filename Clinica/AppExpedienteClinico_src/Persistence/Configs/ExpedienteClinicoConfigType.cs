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
    public class ExpedienteClinicoConfigType : IEntityTypeConfiguration<ExpedienteClinico>
    {
        public void Configure(EntityTypeBuilder<ExpedienteClinico> builder)
        {
            builder.ToTable("ExpedientesClinicos");
            builder.HasKey(x => x.ExpedienteID);
            builder.Property(x => x.ExpedienteID).HasColumnName("ExpedienteID").IsRequired();
            builder.Property(x => x.PacienteID).HasColumnName("PacienteID").IsRequired();
            builder.Property(x => x.NumeroExpediente).HasColumnName("NumeroExpediente").HasMaxLength(50);
            builder.Property(x => x.FechaApertura).HasColumnName("FechaApertura").IsRequired();
            builder.Property(x => x.Descripcion).HasColumnName("Descripcion").HasMaxLength(500);
            builder.Property(x => x.Activo).HasColumnName("Activo").IsRequired();
        }
    }
}
