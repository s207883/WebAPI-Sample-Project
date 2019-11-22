namespace WebApiSample.Core.ViewModels
{
	/// <summary>
	/// Модель представления должности.
	/// </summary>
	public class PositionViewModel
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
