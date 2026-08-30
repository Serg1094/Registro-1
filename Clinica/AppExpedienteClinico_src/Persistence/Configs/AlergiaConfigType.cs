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
    public class AlergiaConfigType : IEntityTypeConfiguration<Alergia>
    {
        public void Configure(EntityTypeBuilder<Alergia> builder)
        {
            builder.ToTable("Alergias");
            builder.HasKey(x => x.AlergiaID);
            builder.Property(x => x.PacienteID).HasColumnName("PacienteID").IsRequired();
            builder.Property(x => x.TipoAlergia).HasColumnName("TipoAlergia").IsRequired().HasMaxLength(100);
            builder.Property(x => x.Alergeno).HasColumnName("Alergeno").IsRequired().HasMaxLength(100);
            builder.Property(x => x.Reaccion).HasColumnName("Reaccion").HasMaxLength(100);
            builder.Property(x => x.Severidad).HasColumnName("Severidad").HasMaxLength(100);
            builder.Property(x => x.Activa).HasColumnName("Activa").IsRequired();

        }
    }

}