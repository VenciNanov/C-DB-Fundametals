using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P01_StudentSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace P01_StudentSystem.Data
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.ToTable("Courses");

            builder.HasKey(e => e.CourseId);

            builder.Property(e => e.Name)
                .IsRequired(true)
                .HasMaxLength(80)
                .IsUnicode(true);

            builder.Property(e => e.Description)
                .IsRequired(false)
                .IsUnicode(true);

            builder.Property(e => e.StartDate)
                .HasColumnType("DATETIME2");

            builder.Property(e => e.EndDate)
                .HasColumnType("DATETIME2");
        }
    }
}
