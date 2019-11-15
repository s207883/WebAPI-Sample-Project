using JetBrains.Annotations;
using LogTZ.DAL.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogTZ.DAL
{
	public class MainContext:DbContext
	{
		/// <summary>
		/// Должности.
		/// </summary>
		public DbSet<Position> Positions { get; set; }

		/// <summary>
		/// Сотрудники.
		/// </summary>
		public DbSet<Employee> Employees { get; set; }
		public MainContext ()
		{
			Database.EnsureCreated();
		}

		protected override void OnModelCreating ( ModelBuilder modelBuilder )
		{
			base.OnModelCreating ( modelBuilder );
		}
	}
}
