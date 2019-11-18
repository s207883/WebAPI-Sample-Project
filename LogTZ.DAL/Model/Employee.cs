using System;
using System.Collections.Generic;

namespace LogTZ.DAL.Model
{
	/// <summary>
	/// Модель сотрудника.
	/// </summary>
	public class Employee
	{
		/// <summary>
		/// ИД сотрудника.
		/// </summary>
		public int EmployeeId { get; set; }

		/// <summary>
		/// Имя сотрудника.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Дата рождения.
		/// </summary>
		public DateTime BirthDate { get; set; }

		#region Навигационные свойства
		public IEnumerable<EmployeePosition> EployeePositions { get; set; }
		#endregion
	}
}
