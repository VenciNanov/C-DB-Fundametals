using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P01_StudentSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace P01_StudentSystem.Data
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Students");

            builder.HasKey(e => e.StudentId);

            builder.Property(e => e.Name)
                .IsRequired(true)
                .HasMaxLength(100)
                .IsUnicode(true);

            builder.Property(e => e.PhoneNumber)
                .IsRequired(false)
                .HasColumnType("CHAR(10)")
                .IsUnicode(false);

            builder.Property(e => e.RegisteredOn)
                .IsRequired(true)
                .HasColumnType("DATETIME2");

            builder.Property(e => e.Birthday)
                .IsRequired(false)
                .HasColumnType("DATETIME2");
        }
    }
}
