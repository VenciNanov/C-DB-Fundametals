using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P03_FootballBetting.Data.Models;
using System;

namespace P03_FootballBetting.Data
{
    public class TownConfig : IEntityTypeConfiguration<Town>
    {
        public TownConfig()
        {
        }
        public void Configure(EntityTypeBuilder<Town> builder)
        {
            builder.ToTable("Towns");

            builder.HasKey(e => e.TownId);

            builder.Property(e => e.Name)
                .IsRequired(true)
                .HasMaxLength(100)
                .IsUnicode(true);

            builder.HasOne(t => t.Country)
                .WithMany(c => c.Towns)
                .HasForeignKey(t => t.CountryId);
        }
    }
}
