using Project.Database.Entities;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace Project.Database
{
    public partial class ProjectDbContext : DbContext
    {

        public DbSet<Professor> Professor { get; set; }
        public DbSet<ScientificRank> ScientificRanks { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<TheForm> TheForms { get; set; }
        public DbSet<LectureHours> LectureHours { get; set; }

        public ProjectDbContext() : base("name=ProjectDbContext")
        {

        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {


            modelBuilder.Entity<Subject>()
                        .HasRequired(o => o.Professor)
                        .WithMany(c => c.Subjects)
                        .HasForeignKey(o => o.ProfessorId)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<Professor>()
            .HasRequired(o => o.ScientificRank)
            .WithMany(c => c.Professors)
            .HasForeignKey(o => o.ScientificRankCode)
            .WillCascadeOnDelete(false);


            modelBuilder.Entity<TheForm>()
            .HasRequired(o => o.Professor)
            .WithMany(c => c.TheForms)
            .HasForeignKey(o => o.ProfessorId)
            .WillCascadeOnDelete(false); ;

            modelBuilder.Entity<TheForm>()
            .HasRequired(o => o.Subject)
            .WithMany(c => c.TheForms)
            .HasForeignKey(o => o.SubjectCode)
            .WillCascadeOnDelete(false);

            modelBuilder.Entity<TheForm>()
            .HasRequired(o => o.ScientificRank)
            .WithMany(c => c.TheForms)
            .HasForeignKey(o => o.ScientificRankCode)
            .WillCascadeOnDelete(false);

            modelBuilder.Entity<TheForm>()
            .HasRequired(o => o.LectureHours)
            .WithMany(c => c.TheForms)
            .HasForeignKey(o => o.LectureHoursId)
            .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);

        }
    }
}
