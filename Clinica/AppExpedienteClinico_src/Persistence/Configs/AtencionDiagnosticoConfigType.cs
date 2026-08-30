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
    public class AtencionDiagnosticoConfigType : IEntityTypeConfiguration<AtencionDiagnostico>
    {
        public void Configure(EntityTypeBuilder<AtencionDiagnostico> builder)
        {
            builder.ToTable("AtencionDiagnostico");
            builder.HasKey(x => x.AtencionDiagnosticoID);
            builder.Property(x => x.AtencionDiagnosticoID).HasColumnName("AtencionDiagnosticoID").IsRequired();
            builder.Property(x => x.AtencionID).HasColumnName("AtencionID").IsRequired();
            builder.Property(x => x.DiagnosticoID).HasColumnName("DiagnosticoID").IsRequired();
            builder.Property(x => x.TipoDiagnostico).HasColumnName("TipoDiagnostico").HasMaxLength(50).IsRequired(false);
            builder.Property(x => x.Observaciones).HasColumnName("Observaciones").HasMaxLength(500).IsRequired(false);
        }
    }
}
