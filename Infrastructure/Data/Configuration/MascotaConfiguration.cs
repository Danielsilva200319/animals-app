using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using core.Entities;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    public class MascotaConfiguration : IEntityTypeConfiguration<Mascota>
    {
        public void Configure(EntityTypeBuilder<Mascota> builder)
        {
            builder.ToTable("Mascota");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);

            builder.Property(p => p.Nombre)
            .IsRequired()
            .HasMaxLength(50);

            builder.Property(p => p.FechaNacimiento)
            .HasColumnType("datetime");

            builder.HasOne(p => p.Razas)
            .WithMany(p => p.Mascotas)
            .HasForeignKey(p => p.IdRaza);

            builder.HasOne(p => p.Clientes)
            .WithMany(p => p.Mascotas)
            .HasForeignKey(p => p.IdCliente);
        }
    }
}