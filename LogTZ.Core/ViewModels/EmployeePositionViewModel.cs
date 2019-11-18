namespace LogTZ.Core.ViewModels
{
	/// <summary>
	/// Модель представления должности сотрудника.
	/// </summary>
	public class EmployeePositionViewModel
	{
		/// <summary>
		/// ИД сотрудника.
		/// </summary>
		public int EmployeeId { get; set; }

		/// <summary>
		/// Должность сотрудника.
		/// </summary>
		public int PositionId { get; set; }

		/// <summary>
		/// Название должности.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Вес должности (грейд).
		/// </summary>
		public int Grade { get; set; }
	}
}
