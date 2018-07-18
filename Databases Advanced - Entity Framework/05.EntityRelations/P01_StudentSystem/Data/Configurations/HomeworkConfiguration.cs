using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P01_StudentSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace P01_StudentSystem.Data
{
    public class HomeworkConfiguration : IEntityTypeConfiguration<Homework>
    {
        public void Configure(EntityTypeBuilder<Homework> builder)
        {
            builder.ToTable("HomeworkSubmissions");

            builder.HasKey(e => e.HomeworkId);

            builder.Property(e => e.Content)
                .IsUnicode(false);

            builder.Property(e => e.SubmissionTime)
                .HasColumnType("DATETIME2");

            builder.HasOne(h => h.Student)
                .WithMany(e => e.HomeworkSubmissions)
                .HasForeignKey(e => e.StudentId);

            builder.HasOne(e => e.Course)
                .WithMany(e => e.HomeworkSubmissions)
                .HasForeignKey(e => e.CourseId);

        }
    }
}
