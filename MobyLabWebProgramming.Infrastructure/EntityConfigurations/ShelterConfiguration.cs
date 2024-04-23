using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MobyLabWebProgramming.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobyLabWebProgramming.Infrastructure.EntityConfigurations
{
    public class ShelterConfiguration : IEntityTypeConfiguration<Shelter>
    {
        public void Configure(EntityTypeBuilder<Shelter> builder)
        {
            // Setează numele tabelului în baza de date
            builder.ToTable("Shelters");

            // Definirea cheii primare
            builder.HasKey(s => s.Id);

            // Definirea restricțiilor de proprietate
            builder.Property(s => s.Name).IsRequired();
            builder.Property(s => s.Location).IsRequired();

            /*

            // Definirea relației one-to-many cu Animal
            builder.HasMany(s => s.Animals)
                   .WithOne(a => a.Shelter)
                   .HasForeignKey(a => a.Id)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Restrict); // Opțional: specifică modul de ștergere

           */
        }
    }
}
