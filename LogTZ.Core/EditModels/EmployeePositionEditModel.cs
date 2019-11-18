namespace LogTZ.Core.EditModels
{
	/// <summary>
	/// Модель представления должности сотрудника.
	/// </summary>
	public class EmployeePositionEditModel
	{
		/// <summary>
		/// ИД сотрудника.
		/// </summary>
		public int EmployeeId { get; set; }

		/// <summary>
		/// Должность сотрудника.
		/// </summary>
		public int PositionId { get; set; }
	}
}
