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
    public class HabitoConfigType : IEntityTypeConfiguration<Habito>
    {
        public void Configure(EntityTypeBuilder<Habito> builder)
        {
            builder.ToTable("Habitos");
            builder.HasKey(x => x.HabitoID);
            builder.Property(x => x.HabitoID).HasColumnName("HabitoID").IsRequired();
            builder.Property(x => x.PacienteID).HasColumnName("PacienteID").IsRequired();
            builder.Property(x => x.TipoHabito).HasColumnName("TipoHabito").IsRequired();
            builder.Property(x => x.Descripcion).HasColumnName("Descripcion").IsRequired(false);
            builder.Property(x => x.Activo).HasColumnName("Activo").IsRequired();

        }
    }
}
