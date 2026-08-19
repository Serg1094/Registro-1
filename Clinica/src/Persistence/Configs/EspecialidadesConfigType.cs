using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configs
{
    public class EspecialidadConfigType : IEntityTypeConfiguration<Especialidades>
    {
        public void Configure(EntityTypeBuilder<Especialidades> builder)
        {
            builder.ToTable("Especialidades");
            builder.HasKey(x => x.EspecialidadID);
            builder.Property(x => x.Codigo).HasColumnName("Codigo").IsRequired();
            builder.Property(x => x.Nombre).HasColumnName("Nombre").IsRequired();
            builder.Property(x => x.Descripcion).HasColumnName("Descripcion");
            builder.Property(x => x.Activo).HasColumnName("Activo");
        }
    }
}