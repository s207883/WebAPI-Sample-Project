using WebApiSample.DAL.Model;
using Microsoft.EntityFrameworkCore;
using System;

namespace WebApiSample.DAL
{
	public class MainContext : DbContext
	{
		/// <summary>
		/// Должности.
		/// </summary>
		public DbSet<Position> Positions { get; set; }

		/// <summary>
		/// Сотрудники.
		/// </summary>
		public DbSet<Employee> Employees { get; set; }

		/// <summary>
		/// Должности сотрудников.
		/// </summary>
		public DbSet<EmployeePosition> EmployeePositions { get; set; }

		/// <summary>
		/// Основной контекст приложения.
		/// </summary>
		public MainContext(DbContextOptions<MainContext> options) : base(options)
		{
			Database.EnsureCreated();
		}

		/// <summary>
		/// Реализация FluentAPI.
		/// </summary>
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			#region Employee Table
			modelBuilder.Entity<Employee>()
				.Property(p => p.BirthDate)
				.HasColumnType("DATE");
			#endregion

			#region EployeePosition Table
			modelBuilder.Entity<EmployeePosition>()
				.HasKey(key => new { key.PositionId, key.EmployeeId });


			modelBuilder.Entity<EmployeePosition>()
				.HasOne(emp => emp.Employee)
				.WithMany(ep => ep.EployeePositions)
				.HasForeignKey(fk => fk.EmployeeId);


			modelBuilder.Entity<EmployeePosition>()
				.HasOne(emp => emp.Position)
				.WithMany(ep => ep.EployeePositions)
				.HasForeignKey(fk => fk.PositionId);
			#endregion

			#region DataInitialisation
			modelBuilder.Entity<Employee>()
				.HasData(
				new Employee { EmployeeId = 1, BirthDate = DateTime.Now, Name = "Ivanov Ivan" },
				new Employee { EmployeeId = 2, BirthDate = DateTime.Now, Name = "Petrov Petr" },
				new Employee { EmployeeId = 3, BirthDate = DateTime.Now, Name = "Nikolaev Nikolay" },
				new Employee { EmployeeId = 4, BirthDate = DateTime.Now, Name = "Aleksey Alekseev" },
				new Employee { EmployeeId = 5, BirthDate = DateTime.Now, Name = "Elena Vasilievna" },
				new Employee { EmployeeId = 6, BirthDate = DateTime.Now, Name = "Mikhail Mikhailov" },
				new Employee { EmployeeId = 7, BirthDate = DateTime.Now, Name = "Prakticant Practicantov" },
				new Employee { EmployeeId = 8, BirthDate = DateTime.Now, Name = "Pavel Pavlov" },
				new Employee { EmployeeId = 9, BirthDate = DateTime.Now, Name = "Steve Jobless" },
				new Employee { EmployeeId = 10, BirthDate = DateTime.Now, Name = "German Jobless" }
				);

			modelBuilder.Entity<Position>()
				.HasData(
				new Position { PositionId = 1, Name = "General director", Grade = 10 },
				new Position { PositionId = 2, Name = "General accountant", Grade = 9 },
				new Position { PositionId = 3, Name = "Office director", Grade = 8 },
				new Position { PositionId = 4, Name = "Office manager", Grade = 7 },
				new Position { PositionId = 5, Name = "Lead developer", Grade = 6 },
				new Position { PositionId = 6, Name = "HR-manager", Grade = 5 },
				new Position { PositionId = 7, Name = "Secretary", Grade = 4 },
				new Position { PositionId = 8, Name = "Engeneer", Grade = 3 },
				new Position { PositionId = 9, Name = "Trainee", Grade = 2 },
				new Position { PositionId = 10, Name = "Cleaner", Grade = 1 }
				);

			modelBuilder.Entity<EmployeePosition>()
				.HasData(
				new EmployeePosition { PositionId = 1, EmployeeId = 1 },
				new EmployeePosition { PositionId = 2, EmployeeId = 1 },
				new EmployeePosition { PositionId = 3, EmployeeId = 1 },
				new EmployeePosition { PositionId = 4, EmployeeId = 2 },
				new EmployeePosition { PositionId = 5, EmployeeId = 3 },
				new EmployeePosition { PositionId = 6, EmployeeId = 4 },
				new EmployeePosition { PositionId = 7, EmployeeId = 5 },
				new EmployeePosition { PositionId = 8, EmployeeId = 6 },
				new EmployeePosition { PositionId = 9, EmployeeId = 7 },
				new EmployeePosition { PositionId = 10, EmployeeId = 8 }
				);
			#endregion

			base.OnModelCreating(modelBuilder);
		}
	}
}
