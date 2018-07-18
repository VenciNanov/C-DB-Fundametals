using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P03_FootballBetting.Data.Models;
using System;

namespace P03_FootballBetting.Data
{
    public class PlayerConfig : IEntityTypeConfiguration<Player>
    {
        public PlayerConfig()
        {
        }

        public void Configure(EntityTypeBuilder<Player> builder)
        {
            builder.HasKey(x => x.PlayerId);

            builder.Property(e=>e.Name)
                .IsRequired(true)
                .HasMaxLength(100)
                .IsUnicode(true);

            builder.Property(e => e.IsInjured)
                .HasDefaultValue(false);

            builder.HasOne(x => x.Team)
                .WithMany(x => x.Players)
                .HasForeignKey(x => x.TeamId);

            builder.HasOne(x => x.Position)
                .WithMany(x => x.Players)
                .HasForeignKey(x => x.PositionId);
        }
    }
}
