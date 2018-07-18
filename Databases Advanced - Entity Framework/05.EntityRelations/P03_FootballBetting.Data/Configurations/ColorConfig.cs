using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P03_FootballBetting.Data.Models;
using System;

namespace P03_FootballBetting.Data
{
    public class ColorConfig : IEntityTypeConfiguration<Color>
    {
        public ColorConfig()
        {
        }

        public void Configure(EntityTypeBuilder<Color> builder)
        {
            builder.HasKey(e => e.ColorId);

            builder.Property(e => e.Name)
                .IsRequired(true)
                .HasMaxLength(100)
                .IsUnicode(true);

            builder.HasMany(c => c.PrimaryKitTeams)
                .WithOne(t => t.PrimaryKitColor)
                .HasForeignKey(c => c.PrimaryKitColorId);

            builder.HasMany(c => c.SecondaryKitTeams)
                .WithOne(t => t.SecondaryKitColor)
                .HasForeignKey(c => c.SecondaryKitColorId);
        }
    }
}
