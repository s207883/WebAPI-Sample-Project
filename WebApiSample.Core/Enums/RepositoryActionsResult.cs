using System;
using System.Collections.Generic;
using System.Text;

namespace WebApiSample.Core.Enums
{
	/// <summary>
	/// Результат работы репозитория.
	/// </summary>
	public enum RepositoryActionsResult
	{
		/// <summary>
		/// Успех.
		/// </summary>
		Success,

		/// <summary>
		/// Неправильный запрос.
		/// </summary>
		BadRequest
	}
}
