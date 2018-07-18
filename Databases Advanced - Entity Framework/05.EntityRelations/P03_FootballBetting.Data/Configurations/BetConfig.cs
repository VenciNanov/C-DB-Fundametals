using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P03_FootballBetting.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03_FootballBetting.Data
{
    public class BetConfig : IEntityTypeConfiguration<Bet>
    {
        public BetConfig()
        {
        }

        public void Configure(EntityTypeBuilder<Bet> builder)
        {
            builder.HasKey(e => e.BetId);

            builder.Property(e => e.Prediction)
                .IsRequired(true)
                .IsUnicode(true);

            builder.Property(e => e.DateTime)
                .HasColumnType("DATETIME2")
                .HasDefaultValue(DateTime.Now);

            builder.Property(e => e.UserId)
                .IsRequired(true);

            builder.Property(e => e.GameId)
                .IsRequired(true);

            builder.HasOne(x => x.Game)
                .WithMany(b => b.Bets)
                .HasForeignKey(x => x.GameId);

            builder.HasOne(b => b.User)
                .WithMany(b => b.Bets)
                .HasForeignKey(x => x.UserId);
        }
    }
}
