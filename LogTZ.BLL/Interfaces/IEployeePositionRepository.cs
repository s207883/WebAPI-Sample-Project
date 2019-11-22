using WebApiSample.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebApiSample.BLL.Interfaces
{
	/// <summary>
	/// Интерфейс репозитория должностей сотрудников.
	/// </summary>
	public interface IEployeePositionRepository
	{
		/// <summary>
		/// Добавляет должность сотруднику.
		/// </summary>
		/// <param name="positionId">Id должности.</param>
		/// <param name="employeeId">Id сотрудника.</param>
		/// <returns>Результат добавления.</returns>
		RepositoryActionsResult SetPositionToEmployee ( int positionId, int employeeId );

		/// <summary>
		/// Удаляет должность у сотрудника.
		/// </summary>
		/// <param name="positionId">Id должности.</param>
		/// <param name="employeeId">Id сотрудника.</param>
		/// <returns>Результат удаления.</returns>
		RepositoryActionsResult RemovePositionFromEmployee ( int positionId, int employeeId );
	}
}
