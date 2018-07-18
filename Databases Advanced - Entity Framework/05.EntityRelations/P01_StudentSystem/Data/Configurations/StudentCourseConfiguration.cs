using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P01_StudentSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace P01_StudentSystem.Data
{
    public class StudentCourseConfiguration : IEntityTypeConfiguration<StudentCourse>
    {
        public void Configure(EntityTypeBuilder<StudentCourse> builder)
        {
            builder.ToTable("StudentCourses");

            builder.HasKey(x => new { x.StudentId, x.CourseId });

            builder.HasOne(e => e.Student)
                .WithMany(e => e.CourseEnrollments)
                .HasForeignKey(e => e.StudentId);

            builder.HasOne(e => e.Course)
                .WithMany(e => e.StudentsEnrolled)
                .HasForeignKey(e => e.CourseId);
        }
    }
}
