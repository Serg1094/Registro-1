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
    public class SintomaConfigType : IEntityTypeConfiguration<Sintoma>
    {
        public void Configure(EntityTypeBuilder<Sintoma> builder)
        {
            builder.ToTable("Sintomas");
            builder.HasKey(x => x.SintomaID);
            builder.Property(x => x.SintomaID).HasColumnName("SintomaID").IsRequired();
            builder.Property(x => x.Nombre).HasColumnName("Nombre").IsRequired();
            builder.Property(x => x.Descripcion).HasColumnName("Descripcion").IsRequired(false);
            builder.Property(x => x.Activo).HasColumnName("Activo").IsRequired();

        }
    }
}
