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
    public class EstadoCitaConfigType : IEntityTypeConfiguration<EstadoCita>
    {
        public void Configure(EntityTypeBuilder<EstadoCita> builder)
        {
            builder.ToTable("Estados_Cita");
            builder.HasKey(x => x.EstadoCitaID);
            builder.Property(x => x.Codigo).HasColumnName("Codigo").IsRequired();
            builder.Property(x => x.Nombre).HasColumnName("Nombre").IsRequired();
        }
    }
}