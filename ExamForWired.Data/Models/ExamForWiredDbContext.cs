using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ExamForWired.Data.Models
{
    public partial class ExamForWiredDbContext : IdentityDbContext<ApplicationUser>
    {
        public ExamForWiredDbContext()
        {
        }

        public ExamForWiredDbContext(DbContextOptions<ExamForWiredDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Exam> Exams { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<Answer> Answers { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Exam>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            builder.Entity<Question>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.HasOne(d => d.Exam)
                   .WithMany(p => p.Questions)
                   .HasForeignKey(d => d.ExamId)
                   .HasConstraintName("FK_Questions_Exam");
            });

            builder.Entity<Answer>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.HasOne(d => d.Question)
                  .WithMany(p => p.Answers)
                  .HasForeignKey(d => d.QuestionId)
                  .HasConstraintName("FK_Answers_Question");
            });

            base.OnModelCreating(builder);
        }
    }
}
