using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P01_StudentSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace P01_StudentSystem.Data
{
    public class ResourceConfiguration : IEntityTypeConfiguration<Resource>
    {
        public void Configure(EntityTypeBuilder<Resource> builder)
        {
            builder.ToTable("Resources");

            builder.HasKey(e => e.ResourceId);

            builder.Property(e => e.Name)
                .IsRequired(true)
                .HasMaxLength(50)
                .IsUnicode(true);

            builder.Property(e => e.Url)
                .IsUnicode(false);

            builder.HasOne(r => r.Course)
                .WithMany(e => e.Resources)
                .HasForeignKey(e => e.CourseId);
        }
    }
}
