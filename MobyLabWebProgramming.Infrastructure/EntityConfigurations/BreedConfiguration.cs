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
    public class BreedConfiguration : IEntityTypeConfiguration<Breed>
    {
        public void Configure(EntityTypeBuilder<Breed> builder)
        {
            // Setează numele tabelului în baza de date
            builder.ToTable("Breeds");

            // Definirea cheii primare
            builder.HasKey(b => b.Id);

            // Definirea restricțiilor de proprietate
            builder.Property(b => b.Name).IsRequired();

            /*

            // Definirea relației one-to-many cu Animal
            builder.HasMany(b => b.Animals)
                   .WithOne(a => a.Breed)
                   .HasForeignKey(a => a.Id)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Restrict); // Opțional: specifică modul de ștergere

          */
        }
    }
}
