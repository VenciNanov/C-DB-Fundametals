using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P03_FootballBetting.Data.Models;
using System;

namespace P03_FootballBetting.Data
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public UserConfig()
        {
        }

        public void Configure(EntityTypeBuilder<User> builder)
        {

            builder.HasKey(e => e.UserId);

            builder.Property(e => e.Username)
                .IsRequired(true)
                .HasMaxLength(50)
                .IsUnicode(true);

            builder.Property(e => e.Password)
                .IsRequired(true)
                .HasMaxLength(50)
                .IsUnicode(true);

            builder.Property(e => e.Email)
                .IsRequired(true)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Name)
                .IsRequired(true)
                .HasMaxLength(100)
                .IsUnicode(true);
        }
    }
}
