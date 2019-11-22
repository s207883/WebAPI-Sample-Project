using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebApiSample.Core.EditModels
{
	public class PositionEditModel
	{
		/// <summary>
		/// ИД должности.
		/// </summary>
		public int PositionId { get; set; }

		/// <summary>
		/// Название должности.
		/// </summary>
		[Required ( ErrorMessage = "Требуется имя" )]
		public string Name { get; set; }

		/// <summary>
		/// Вес должности (грейд).
		/// </summary>
		[Required]
		[Range (1, 15, ErrorMessage = "Недопустимый грейд")]
		public int Grade { get; set; }
	}
}
