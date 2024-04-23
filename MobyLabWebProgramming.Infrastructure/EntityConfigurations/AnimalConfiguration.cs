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
    public class AnimalConfiguration : IEntityTypeConfiguration<Animal>
    {
        public void Configure(EntityTypeBuilder<Animal> builder)
        {
            builder.Property(e => e.Id)
                .IsRequired();
            builder.HasKey(x => x.Id);
            builder.Property(e => e.Name)
                .HasMaxLength(255)
                .IsRequired();
            builder.Property(e => e.Age)
                .IsRequired();
            builder.Property(e => e.IsAvailable)
                .IsRequired();
            builder.Property(e => e.AvailableUntil)
                .IsRequired();

            
          
            // Relația many-to-one cu Shelter
            builder.HasOne(a => a.Shelter)
                .WithMany(s => s.Animals)
                .HasForeignKey(a => a.ShelterId)
                .OnDelete(DeleteBehavior.Cascade);

            // Relația many-to-one cu Breed
            builder.HasOne(a => a.Breed)
                .WithMany(b => b.Animals)
                .HasForeignKey(a => a.BreedId)
                .OnDelete(DeleteBehavior.Cascade);

            

        }
    }
}
