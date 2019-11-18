using LogTZ.DAL.Model;
using Microsoft.EntityFrameworkCore;

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
		public DbSet<EployeePosition> EployeePositions { get; set; }

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
			modelBuilder.Entity<EployeePosition> ( )
				.HasKey ( key => new { key.PositionId, key.EmployeeId } );


			modelBuilder.Entity<EployeePosition> ( )
				.HasOne ( emp => emp.Employee )
				.WithMany ( ep => ep.EployeePositions )
				.HasForeignKey ( fk => fk.EmployeeId );


			modelBuilder.Entity<EployeePosition> ( )
				.HasOne ( emp => emp.Position )
				.WithMany ( ep => ep.EployeePositions )
				.HasForeignKey ( fk => fk.PositionId );
			#endregion

			base.OnModelCreating ( modelBuilder );
		}
	}
}
