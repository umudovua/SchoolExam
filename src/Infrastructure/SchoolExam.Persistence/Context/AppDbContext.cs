using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SchoolExam.Domain.Entities;
using SchoolExam.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace SchoolExam.Persistence.Context
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{
		}

		public DbSet<ClassRoom> ClassRooms { get; set; }
		public DbSet<Exam> Exams { get; set; }
		public DbSet<Lesson> Lessons { get; set; }
		public DbSet<Student> Students { get; set; }
		public DbSet<Teacher> Teachers { get; set; }



		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Exam>()
				.HasOne(e => e.Lesson)
				.WithMany(l => l.Exams)
				.HasForeignKey(e => e.LessonId)
				.OnDelete(DeleteBehavior.Cascade);
			
			modelBuilder.Entity<Exam>()
				.HasOne(e => e.Student)
				.WithMany(s => s.Exams)
				.HasForeignKey(e => e.StudentId)
				.OnDelete(DeleteBehavior.NoAction);

			modelBuilder.Entity<Lesson>()
				.HasOne(l => l.Teacher)
				.WithOne(t => t.Lesson)
				.HasForeignKey<Lesson>(l => l.TeacherId)
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<ClassRoom>()
				.Property(c => c.Number)
			.HasPrecision(18, 2);
			base.OnModelCreating(modelBuilder);
		}


		public void StatedByAddedAndModifie(IEnumerable<EntityEntry<BaseEntity>> entries)
		{
			foreach (var entry in entries)
			{
				switch (entry.State)
				{
					case EntityState.Added:
						entry.Entity.CreateDate = DateTime.Now;
						break;
					case EntityState.Modified:
						entry.Entity.UpdateDate = DateTime.Now;
						break;
				}

			}
		}


	}
}
