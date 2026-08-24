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
    public class ContactoEmergenciaConfigType : IEntityTypeConfiguration<Contacto_Emergencia>
    {
        public void Configure(EntityTypeBuilder<Contacto_Emergencia> builder)
        {
            builder.ToTable("Contactos_Emergencia");
            builder.HasKey(x => x.ContactoEmergenciaID);
            builder.Property(x => x.PacienteID).HasColumnName("PacienteID").IsRequired();
            builder.Property(x => x.NombreCompleto).HasColumnName("NombreCompleto").IsRequired();
            builder.Property(x => x.Parentesco).HasColumnName("Parentesco");
            builder.Property(x => x.Telefono).HasColumnName("Telefono").IsRequired();
            builder.Property(x => x.TelefonoSecundario).HasColumnName("TelefonoSecundario");
            builder.Property(x => x.Email).HasColumnName("Email");
            builder.Property(x => x.Prioridad).HasColumnName("Prioridad");
            builder.Property(x => x.Activo).HasColumnName("Activo");
        }
    }
}
