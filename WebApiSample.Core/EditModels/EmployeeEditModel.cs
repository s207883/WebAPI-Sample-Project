using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebApiSample.Core.EditModels
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
		[Required(ErrorMessage = "Требуется имя")]
		public string Name { get; set; }

		/// <summary>
		/// Дата рождения.
		/// </summary>
		[Required(ErrorMessage = "Требудется дата рождения")]
		public DateTime BirthDate { get; set; }
	}
}
