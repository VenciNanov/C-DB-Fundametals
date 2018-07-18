using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P03_FootballBetting.Data.Models;
using System;

namespace P03_FootballBetting.Data
{
    public class GameConfiguration : IEntityTypeConfiguration<Game>
    {
        public GameConfiguration()
        {
        }

        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.HasKey(e => e.GameId);

            builder.Property(e => e.DateTime)
                .HasColumnType("DATETIME2");

            builder.HasOne(e => e.HomeTeam)
                .WithMany(e => e.HomeGames)
                .HasForeignKey(g => g.HomeTeamId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.AwayTeam)
                .WithMany(t => t.AwayGames)
                .HasForeignKey(g => g.AwayTeamId);
        }
    }
}
