using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P03_FootballBetting.Data.Models;
using System;

namespace P03_FootballBetting.Data
{
    public class PositionConfig : IEntityTypeConfiguration<Position>
    {
        public PositionConfig()
        {
        }

        public void Configure(EntityTypeBuilder<Position> builder)
        {
            builder.HasKey(x => x.PositionId);

            builder.Property(e=>e.Name)
                .IsRequired(true)
                .HasMaxLength(100)
                .IsUnicode(true);
        }
    }
}
