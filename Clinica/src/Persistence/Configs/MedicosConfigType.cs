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
    public class MedicoConfigType : IEntityTypeConfiguration<Medicos>
    {
        public void Configure(EntityTypeBuilder<Medicos> builder)
        {
            builder.ToTable("Medicos");
            builder.HasKey(x => x.MedicoID);
            builder.Property(x => x.UsuarioID).HasColumnName("UsuarioID");
            builder.Property(x => x.CodigoMedico).HasColumnName("CodigoMedico").IsRequired();
            builder.Property(x => x.Nombres).HasColumnName("Nombres").IsRequired();
            builder.Property(x => x.Apellidos).HasColumnName("Apellidos").IsRequired();
            builder.Property(x => x.NumeroLicencia).HasColumnName("NumeroLicencia");
            builder.Property(x => x.Telefono).HasColumnName("Telefono");
            builder.Property(x => x.Email).HasColumnName("Email");
            builder.Property(x => x.Activo).HasColumnName("Activo");
        }
    }
}
