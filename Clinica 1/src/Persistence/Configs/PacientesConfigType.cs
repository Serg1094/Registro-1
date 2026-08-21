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
    public class PacienteConfigType : IEntityTypeConfiguration<Pacientes>
    {
        public void Configure(EntityTypeBuilder<Pacientes> builder)
        {
            builder.ToTable("Pacientes");
            builder.HasKey(x => x.PacienteID);
            builder.Property(x => x.CodigoPaciente).HasColumnName("CodigoPaciente").IsRequired();
            builder.Property(x => x.TipoDocumento).HasColumnName("TipoDocumento").IsRequired();
            builder.Property(x => x.NumeroDocumento).HasColumnName("NumeroDocumento").IsRequired();
            builder.Property(x => x.Nombres).HasColumnName("Nombres").IsRequired();
            builder.Property(x => x.Apellidos).HasColumnName("Apellidos").IsRequired();
            builder.Property(x => x.FechaNacimiento).HasColumnName("FechaNacimiento");
            builder.Property(x => x.Sexo).HasColumnName("Sexo");
            builder.Property(x => x.EstadoCivil).HasColumnName("EstadoCivil");
            builder.Property(x => x.Telefono).HasColumnName("Telefono");
            builder.Property(x => x.TelefonoSecundario).HasColumnName("TelefonoSecundario");
            builder.Property(x => x.Email).HasColumnName("Email");
            builder.Property(x => x.Direccion).HasColumnName("Direccion");
            builder.Property(x => x.Ciudad).HasColumnName("Ciudad");
            builder.Property(x => x.Pais).HasColumnName("Pais");
            builder.Property(x => x.Ocupacion).HasColumnName("Ocupacion");
            builder.Property(x => x.TipoSangre).HasColumnName("TipoSangre");
            builder.Property(x => x.Activo).HasColumnName("Activo");
            builder.Property(x => x.FechaRegistro).HasColumnName("FechaRegistro");
        }
    }
}
