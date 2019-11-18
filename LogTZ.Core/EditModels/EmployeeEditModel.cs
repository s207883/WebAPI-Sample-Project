using System;
using System.Collections.Generic;
using System.Text;

namespace LogTZ.Core.EditModels
{
	public class EmployeeEditModel
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
	}
}
