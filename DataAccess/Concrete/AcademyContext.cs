﻿using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class AcademyContext :IdentityDbContext<AppUser,AppRole,int>
    {
     
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=CODECYBER\\SQLEXPRESS;database=DbAcademy;integrated security=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //modelBuilder.Entity<Lesson>()
            // .HasOne(l => l.Subject)
            // .WithMany(s => s.Lessons)
            // .HasForeignKey(l => l.SubjectId)
            // .OnDelete(DeleteBehavior.NoAction);

            //Question FluentApi
            modelBuilder.Entity<Question>()
                .HasOne(q => q.Level)
                .WithMany()
                .HasForeignKey(q => q.LevelId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Question>()
                .HasOne(q => q.Output)
                .WithMany()
                .HasForeignKey(q => q.OutputId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Question>()
                .HasOne(q => q.Subject)
                .WithMany(s => s.Questions)
                .HasForeignKey(q => q.SubjectId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Question>()
                .HasOne(q => q.User)
                .WithMany()
                .HasForeignKey(q => q.UserId)
                .OnDelete(DeleteBehavior.Restrict);
    
            //Lesson Fluent Api
            modelBuilder.Entity<Lesson>()
                  .HasOne(q => q.Class)
                  .WithMany()
                  .HasForeignKey(q => q.ClassId)
                  .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Lesson>()
                .HasOne(q => q.Subject)
                .WithMany()
                .HasForeignKey(q => q.SubjectId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Lesson>()
                .HasOne(q => q.User)
                .WithMany()
                .HasForeignKey(q => q.UserId)
                .OnDelete(DeleteBehavior.Restrict);


            //Exam Fluent Api

            modelBuilder.Entity<Exam>()
                 .HasOne(q => q.Class)
                 .WithMany()
                 .HasForeignKey(q => q.ClassId)
                 .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Exam>()
                .HasOne(q => q.Subject)
                .WithMany()
                .HasForeignKey(q => q.SubjectId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Exam>()
                .HasOne(q => q.User)
                .WithMany()
                .HasForeignKey(q => q.UserId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Exam>()
                 .HasOne(q => q.Lesson)
                 .WithMany()
                 .HasForeignKey(q => q.LessonId)
                 .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Exam>()
                 .HasOne(q => q.Question)
                 .WithMany()
                 .HasForeignKey(q => q.QuestionId)
                 .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Cart> Carts { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Level> Levels { get; set; }
        public DbSet<Solution> Solutions { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Output> Outputs { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Exam> Exams { get; set; }

       
    }
}
