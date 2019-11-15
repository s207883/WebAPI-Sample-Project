namespace LogTZ.DAL.Model
{
	public class EployeePosition
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
