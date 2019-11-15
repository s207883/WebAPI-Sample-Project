using System;
using System.Collections.Generic;
using System.Text;

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
		public int CustomerId { get; set; }

		/// <summary>
		/// Имя сотрудника.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Дата рождения.
		/// </summary>
		public DateTime BirthDate { get; set; }
	}
}
