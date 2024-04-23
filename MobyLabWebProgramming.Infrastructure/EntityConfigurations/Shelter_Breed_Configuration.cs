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
    public class Shelter_Breed_Configuration : IEntityTypeConfiguration<Shelter_Breed>
    {
        public void Configure(EntityTypeBuilder<Shelter_Breed> builder)
        {
            builder.ToTable("Shelter_Breed");

            // Setarea cheii primare compuse
            builder.HasKey(i => new { i.ShelterId, i.BreedId });

            // Configurarea relației many-to-many între Food și Ingredient prin entitatea intermediară
            builder.HasOne(i => i.Shelter)
                .WithMany(i => i.Shelter_Breeds)
                .HasForeignKey(i => i.ShelterId);

            builder.HasOne(i => i.Breed)
                .WithMany(i => i.Shelter_Breeds)
                .HasForeignKey(i => i.BreedId);
        }
    }
}
