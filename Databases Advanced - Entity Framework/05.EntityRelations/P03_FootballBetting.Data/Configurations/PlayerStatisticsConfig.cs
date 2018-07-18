using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P03_FootballBetting.Data.Models;
using System;

namespace P03_FootballBetting.Data
{
    public class PlayerStatisticsConfig : IEntityTypeConfiguration<PlayerStatistic>
    {
        public PlayerStatisticsConfig()
        {
        }

        public void Configure(EntityTypeBuilder<PlayerStatistic> builder)
        {
            builder.HasKey(e => new { e.PlayerId, e.GameId });

            builder.HasOne(x => x.Player)
                .WithMany(x => x.PlayerStatistics)
                .HasForeignKey(x => x.PlayerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Game)
                .WithMany(x => x.PlayerStatistics)
                .HasForeignKey(x => x.GameId);
        }
    }
}
