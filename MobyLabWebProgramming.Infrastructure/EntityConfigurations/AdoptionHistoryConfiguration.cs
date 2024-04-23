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
    public class AdoptionHistoryConfiguration : IEntityTypeConfiguration<AdoptionHistory>
    {
        public void Configure(EntityTypeBuilder<AdoptionHistory> builder)
        {
            builder.HasKey(e => new { e.UserId, e.AnimalId });

            builder.HasOne(e => e.User)
                .WithMany(u => u.AdoptedAnimals)
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.Animal)
                .WithMany(a => a.AdoptedByUsers)
                .HasForeignKey(e => e.AnimalId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
