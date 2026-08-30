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
    public class AtencionSintomaConfigType : IEntityTypeConfiguration<AtencionSintoma>
    {
        public void Configure(EntityTypeBuilder<AtencionSintoma> builder)
        {
            builder.ToTable("AtencionSintoma");
            builder.HasKey(x => x.AtencionSintomaID);
            builder.Property(x => x.AtencionSintomaID).HasColumnName("AtencionSintomaID").IsRequired();
            builder.Property(x => x.AtencionID).HasColumnName("AtencionID").IsRequired();
            builder.Property(x => x.SintomaID).HasColumnName("SintomaID").IsRequired();
            builder.Property(x => x.Intensidad).HasColumnName("Intensidad").HasMaxLength(50);
            builder.Property(x => x.Duracion).HasColumnName("Duracion").IsRequired();
            builder.Property(x => x.Observaciones).HasColumnName("Observaciones").HasMaxLength(500);
        }
    }
}
