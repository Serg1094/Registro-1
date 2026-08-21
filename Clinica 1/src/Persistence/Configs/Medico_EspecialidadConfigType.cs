using Core.Interfaces.Repositories;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configs
{
    public class Medico_EspecialidadConfigType : IEntityTypeConfiguration<Medico_Especialidad>
    {
        public void Configure(EntityTypeBuilder<Medico_Especialidad> builder)
        {
            builder.ToTable("Medico_Especialidad");
            builder.HasKey(x => new { x.MedicoID, x.EspecialidadID });
            builder.Property(x => x.MedicoID).HasColumnName("MedicoID");
            builder.Property(x => x.EspecialidadID).HasColumnName("EspecialidadID");
            builder.Property(x => x.Principal).HasColumnName("Principal");
        }
    }
}