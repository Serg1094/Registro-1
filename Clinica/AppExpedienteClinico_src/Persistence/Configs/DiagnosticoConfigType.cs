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
    public class DiagnosticoConfigType : IEntityTypeConfiguration<Diagnostico>
    {
        public void Configure(EntityTypeBuilder<Diagnostico> builder)
        {
            builder.ToTable("Diagnosticos");
            builder.HasKey(x => x.DiagnosticoID);
            builder.Property(x => x.CodigoCIE10).IsRequired().HasMaxLength(10);
            builder.Property(x => x.Nombre).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Descripcion).HasMaxLength(500);
            builder.Property(x => x.Activo).IsRequired();

        }
    }
}
