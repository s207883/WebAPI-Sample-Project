using LogTZ.DAL.Model;
using Microsoft.EntityFrameworkCore;
using System;

namespace LogTZ.DAL
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
		public MainContext (DbContextOptions<MainContext> options):base(options)
		{
			Database.EnsureCreated ( );
		}

		/// <summary>
		/// Реализация FluentAPI.
		/// </summary>
		protected override void OnModelCreating ( ModelBuilder modelBuilder )
		{
			#region EployeePosition Table
			modelBuilder.Entity<EmployeePosition> ( )
				.HasKey ( key => new { key.PositionId, key.EmployeeId } );


			modelBuilder.Entity<EmployeePosition> ( )
				.HasOne ( emp => emp.Employee )
				.WithMany ( ep => ep.EployeePositions )
				.HasForeignKey ( fk => fk.EmployeeId );


			modelBuilder.Entity<EmployeePosition> ( )
				.HasOne ( emp => emp.Position )
				.WithMany ( ep => ep.EployeePositions )
				.HasForeignKey ( fk => fk.PositionId );
			#endregion

			#region DataInitialisation
			modelBuilder.Entity<Employee> ( )
				.HasData (
				new Employee { EmployeeId = 1, BirthDate = DateTime.Now, Name = Guid.NewGuid ( ).ToString ( ) },
				new Employee { EmployeeId = 2, BirthDate = DateTime.Now, Name = Guid.NewGuid ( ).ToString ( ) },
				new Employee { EmployeeId = 3, BirthDate = DateTime.Now, Name = Guid.NewGuid ( ).ToString ( ) },
				new Employee { EmployeeId = 4, BirthDate = DateTime.Now, Name = Guid.NewGuid ( ).ToString ( ) },
				new Employee { EmployeeId = 5, BirthDate = DateTime.Now, Name = Guid.NewGuid ( ).ToString ( ) },
				new Employee { EmployeeId = 6, BirthDate = DateTime.Now, Name = Guid.NewGuid ( ).ToString ( ) },
				new Employee { EmployeeId = 7, BirthDate = DateTime.Now, Name = Guid.NewGuid ( ).ToString ( ) },
				new Employee { EmployeeId = 8, BirthDate = DateTime.Now, Name = Guid.NewGuid ( ).ToString ( ) },
				new Employee { EmployeeId = 9, BirthDate = DateTime.Now, Name = Guid.NewGuid ( ).ToString ( ) },
				new Employee { EmployeeId = 10, BirthDate = DateTime.Now, Name = Guid.NewGuid ( ).ToString ( ) }
				);

			modelBuilder.Entity<Position> ( )
				.HasData (
				new Position { PositionId = 1, Name = Guid.NewGuid ( ).ToString ( ), Grade = 1 },
				new Position { PositionId = 2, Name = Guid.NewGuid ( ).ToString ( ), Grade = 2 },
				new Position { PositionId = 3, Name = Guid.NewGuid ( ).ToString ( ), Grade = 3 },
				new Position { PositionId = 4, Name = Guid.NewGuid ( ).ToString ( ), Grade = 4 },
				new Position { PositionId = 5, Name = Guid.NewGuid ( ).ToString ( ), Grade = 5 },
				new Position { PositionId = 6, Name = Guid.NewGuid ( ).ToString ( ), Grade = 6 },
				new Position { PositionId = 7, Name = Guid.NewGuid ( ).ToString ( ), Grade = 7 },
				new Position { PositionId = 8, Name = Guid.NewGuid ( ).ToString ( ), Grade = 8 },
				new Position { PositionId = 9, Name = Guid.NewGuid ( ).ToString ( ), Grade = 9 },
				new Position { PositionId = 10, Name = Guid.NewGuid ( ).ToString ( ), Grade = 10 }
				);

			modelBuilder.Entity<EmployeePosition> ( )
				.HasData (
				new EmployeePosition { PositionId = 1, EmployeeId = 1 },
				new EmployeePosition { PositionId = 2, EmployeeId = 1 },
				new EmployeePosition { PositionId = 3, EmployeeId = 1 },
				new EmployeePosition { PositionId = 4, EmployeeId = 1 },
				new EmployeePosition { PositionId = 5, EmployeeId = 1 },
				new EmployeePosition { PositionId = 6, EmployeeId = 2 },
				new EmployeePosition { PositionId = 7, EmployeeId = 3 },
				new EmployeePosition { PositionId = 8, EmployeeId = 4 },
				new EmployeePosition { PositionId = 9, EmployeeId = 5 },
				new EmployeePosition { PositionId = 10, EmployeeId = 6 }
				);
			#endregion

			base.OnModelCreating ( modelBuilder );
		}
	}
}
