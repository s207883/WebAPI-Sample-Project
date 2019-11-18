using System.ComponentModel.DataAnnotations;

namespace LogTZ.Core.EditModels
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
		public int EmployeeId { get; set; }

		/// <summary>
		/// Id должности.
		/// </summary>
		[Required ( ErrorMessage = "Идентификатор долности не установлен" )]
		public int PositionId { get; set; }
	}
}
