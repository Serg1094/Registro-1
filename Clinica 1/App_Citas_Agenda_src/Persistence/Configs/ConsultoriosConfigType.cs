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
    public class ConsultorioConfigType : IEntityTypeConfiguration<Consultorio>
    {
        public void Configure(EntityTypeBuilder<Consultorio> builder)
        {
            builder.ToTable("Consultorios");
            builder.HasKey(x => x.ConsultorioID);
            builder.Property(x => x.SucursalID).HasColumnName("SucursalID").IsRequired();
            builder.Property(x => x.AreaID).HasColumnName("AreaID");
            builder.Property(x => x.Codigo).HasColumnName("Codigo").IsRequired();
            builder.Property(x => x.Nombre).HasColumnName("Nombre").IsRequired();
            builder.Property(x => x.Piso).HasColumnName("Piso");
            builder.Property(x => x.Activo).HasColumnName("Activo");
        }
    }
}