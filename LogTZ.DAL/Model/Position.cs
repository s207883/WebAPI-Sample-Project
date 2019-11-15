namespace LogTZ.DAL.Model
{
	/// <summary>
	/// Модель должности.
	/// </summary>
	public class Position
	{
		/// <summary>
		/// ИД должности.
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
