using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P03_FootballBetting.Data.Models;
using System;

namespace P03_FootballBetting.Data
{
    public class CountryConfig : IEntityTypeConfiguration<Country>
    {
        public CountryConfig()
        {
        }

        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasKey(e => e.CountryId);

            builder.Property(e => e.Name)
                .IsRequired(true)
                .HasMaxLength(100)
                .IsUnicode(true);
        }
    }
}
