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
    public class AntecedenteFamiliarConfigType : IEntityTypeConfiguration<AntecedenteFamiliar>
    {
        public void Configure(EntityTypeBuilder<AntecedenteFamiliar> builder)
        {
            builder.ToTable("AntecedentesFamiliares");
            builder.HasKey(x => x.AntecedenteFamiliarID);
            builder.Property(builder => builder.PacienteID).IsRequired();
            builder.Property(builder => builder.Parentesco).IsRequired().HasMaxLength(50);
            builder.Property(builder => builder.Enfermedad).IsRequired().HasMaxLength(100);
            builder.Property(builder => builder.Observaciones).HasMaxLength(200);
            builder.Property(builder => builder.FechaRegistro).IsRequired();

        }
    }
}
