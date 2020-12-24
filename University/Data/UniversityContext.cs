using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using University.Data.Models;

namespace University.Data
{
    class UniversityContext : DbContext
    {
        public UniversityContext() : base()
        {

        }
        public UniversityContext(DbContextOptions options)
            : base(options)
        {
        }

        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Resource> Resources { get; set; }
        public virtual DbSet<Homework> HomeworkSubmissions { get; set; }
        public virtual DbSet<StudentCourse> StudentCourses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            if (!optionBuilder.IsConfigured)
            {
                optionBuilder.UseSqlServer(@"Server=DESKTOP-IT4ICGD\PRODAMGARAJ;Database=UniversityContext;Trusted_Connection=True;");
            }
            base.OnConfiguring(optionBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentCourse>(entity =>
            {
                entity.HasKey(sc => new { sc.CourseId, sc.StudentId });
            });
        }

    }
}
