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
    public class ProfileConfiguration : IEntityTypeConfiguration<Profile>
    {
        public void Configure(EntityTypeBuilder<Profile> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Address)
                .HasMaxLength(255); // Setează lungimea maximă a adresei

            builder.Property(p => p.ImageUrl)
                .HasMaxLength(255); // Setează lungimea maximă a URL-ului imaginii

            builder.Property(p => p.Description)
                .HasMaxLength(255);

            // Relația one-to-one cu User
            builder.HasOne(p => p.User)
                .WithOne(u => u.Profile)
                .HasForeignKey<Profile>(p => p.UserId) // Cheia străină este cheia primară a Profile
                ; // Cascadează ștergerea Profile atunci când se șterge User-ul asociat

            builder.ToTable("Profiles");
        }
    }
}
