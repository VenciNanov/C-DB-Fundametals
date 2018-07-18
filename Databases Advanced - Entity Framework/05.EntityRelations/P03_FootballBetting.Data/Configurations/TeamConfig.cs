using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P03_FootballBetting.Data.Models;
using System;

namespace P03_FootballBetting.Data
{
    public class TeamConfig : IEntityTypeConfiguration<Team>
    {
        public TeamConfig()
        {
        }

        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.HasKey(e => e.TeamId);

            builder.Property(e => e.Name)
               .IsRequired(true)
               .IsUnicode(true)
               .HasMaxLength(100);

            builder.Property(e => e.LogoUrl)
                .IsRequired(true)
                .HasMaxLength(100);

            builder.Property(e => e.Initials)
                .IsRequired(true)
                .HasColumnType("CHAR(3)")
                .IsUnicode(true);

            builder.Property(e => e.Budget)
                .IsRequired(true);

            builder.HasOne(x => x.PrimaryKitColor)
                .WithMany(x => x.PrimaryKitTeams)
                .HasForeignKey(x => x.PrimaryKitColorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.SecondaryKitColor)
                .WithMany(x => x.SecondaryKitTeams)
                .HasForeignKey(x => x.SecondaryKitColorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Town)
                .WithMany(x => x.Teams)
                .HasForeignKey(x => x.TownId);

        }
    }
}
