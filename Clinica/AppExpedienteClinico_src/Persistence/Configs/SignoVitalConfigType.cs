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
    public class SignoVitalConfigType : IEntityTypeConfiguration<SignoVital>
    {
        public void Configure(EntityTypeBuilder<SignoVital> builder)
        {
            builder.ToTable("Signos_Vitales");
            builder.HasKey(x => x.SignosVitalesID);
            builder.Property(x => x.SignosVitalesID).HasColumnName("SignosVitalesID").IsRequired();
            builder.Property(x => x.AtencionID).HasColumnName("AtencionID").IsRequired();
            builder.Property(x => x.FechaRegistro).HasColumnName("FechaRegistro").IsRequired();
            builder.Property(x => x.PresionSistolica).HasColumnName("PresionSistolica").IsRequired();
            builder.Property(x => x.PresionDiastolica).HasColumnName("PresionDiastolica").IsRequired();
            builder.Property(x => x.FrecuenciaCardiaca).HasColumnName("FrecuenciaCardiaca").IsRequired();
            builder.Property(x => x.FrecuenciaRespiratoria).HasColumnName("FrecuenciaRespiratoria").IsRequired();
            builder.Property(x => x.Temperatura).HasColumnName("Temperatura").IsRequired();
            builder.Property(x => x.SaturacionOxigeno).HasColumnName("SaturacionOxigeno").IsRequired();
            builder.Property(x => x.PesoKg).HasColumnName("PesoKg").IsRequired();
            builder.Property(x => x.TallaCm).HasColumnName("TallaCm").IsRequired();
            builder.Property(x => x.IMC).HasColumnName("IMC").IsRequired(false);
            builder.Property(x => x.Observaciones).HasColumnName("Observaciones").IsRequired(false);
        }
    }
}
