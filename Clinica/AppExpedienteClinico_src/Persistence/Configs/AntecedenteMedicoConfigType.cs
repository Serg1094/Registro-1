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
    public class AntecedenteMedicoConfigType : IEntityTypeConfiguration<AntecedenteMedico>
    {
        public void Configure(EntityTypeBuilder<AntecedenteMedico> builder)
        {
            builder.ToTable("AntecedentesMedicos");
            builder.HasKey(x => x.AntecedenteMedicoID);
            builder.Property(builder => builder.PacienteID).IsRequired();
            builder.Property(builder => builder.TipoAntecedente).IsRequired();
            builder.Property(builder => builder.Descripcion).IsRequired(false);
            builder.Property(builder => builder.FechaReferencia).IsRequired(false);
            builder.Property(builder => builder.Observaciones).IsRequired(false);
            builder.Property(builder => builder.FechaRegistro).IsRequired(false);
        }
    }
}
