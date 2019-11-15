using LogTZ.Core.EditModels;
using LogTZ.Core.Enums;
using LogTZ.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogTZ.BLL.Interfaces
{
	/// <summary>
	/// Интерфейс репозитория сотрудников.
	/// </summary>
	public interface IEmployeeRepository
	{
		/// <summary>
		/// Создать сотрудника.
		/// </summary>
		/// <param name="employeeEditModel">Модель сотрудника.</param>
		/// <returns>Результат добавления.</returns>
		RepositoryActionsResult CreateEmployee ( EmployeeEditModel employeeEditModel);

		/// <summary>
		/// Обновить сотрудника.
		/// </summary>
		/// <param name="employeeEditModel">Модель сотрудника.</param>
		/// <returns>Результат обновления.</returns>
		RepositoryActionsResult UpdateEmployee ( EmployeeEditModel employeeEditModel );

		/// <summary>
		/// Удалить сотрудника по Id.
		/// </summary>
		/// <param name="employeeId">Id сотрудника.</param>
		/// <returns>Результат удаления.</returns>
		RepositoryActionsResult DeleteEmployeeById ( int employeeId );

		/// <summary>
		/// Получить сотрудника по Id.
		/// </summary>
		/// <param name="employeeId">Id сотрудника.</param>
		/// <returns>Результат поиска и модель.</returns>
		(RepositoryActionsResult repositoryActionResult, EmployeeViewModel employeeViewModel) GetEmployeeById ( int employeeId );
	}
}
