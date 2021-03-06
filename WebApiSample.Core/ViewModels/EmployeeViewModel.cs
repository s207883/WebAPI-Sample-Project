﻿using System;
using System.Collections.Generic;

namespace WebApiSample.Core.ViewModels
{
	/// <summary>
	/// Модель представления сотрудника.
	/// </summary>
	public class EmployeeViewModel
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

		/// <summary>
		/// Должности сотрудника.
		/// </summary>
		public IEnumerable<EmployeePositionViewModel> Positions { get; set; }
	}
}
