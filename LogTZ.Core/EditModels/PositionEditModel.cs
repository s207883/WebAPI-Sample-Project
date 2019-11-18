using System;
using System.Collections.Generic;
using System.Text;

namespace LogTZ.Core.EditModels
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
		public string Name { get; set; }

		/// <summary>
		/// Вес должности (грейд).
		/// </summary>
		public int Grade { get; set; }
	}
}
