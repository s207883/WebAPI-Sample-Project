﻿namespace WebApiSample.DAL.Model
{
	public class EmployeePosition
	{
		/// <summary>
		/// ИД сотрудника.
		/// </summary>
		public int EmployeeId { get; set; }

		/// <summary>
		/// Должность сотрудника.
		/// </summary>
		public int PositionId { get; set; }

		#region Навигационные свойства
		public Employee Employee { get; set; }
		public Position Position { get; set; }
		#endregion
	}
}
