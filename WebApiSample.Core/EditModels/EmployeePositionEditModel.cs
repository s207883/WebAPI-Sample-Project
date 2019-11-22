using System.ComponentModel.DataAnnotations;

namespace WebApiSample.Core.EditModels
{
	/// <summary>
	/// Модель представления должности сотрудника.
	/// </summary>
	public class EmployeePositionEditModel
	{
		/// <summary>
		/// Id сотрудника.
		/// </summary>
		[Required ( ErrorMessage = "Идентификатор сотрудника не установлен" )]
		[Range (0, int.MaxValue, ErrorMessage = "Недопустимый Id" )]
		public int EmployeeId { get; set; }

		/// <summary>
		/// Id должности.
		/// </summary>
		[Required ( ErrorMessage = "Идентификатор долности не установлен" )]
		[Range ( 0, int.MaxValue, ErrorMessage = "Недопустимый Id" )]
		public int PositionId { get; set; }
	}
}
