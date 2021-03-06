﻿using WebApiSample.Core.EditModels;
using WebApiSample.Core.Enums;
using WebApiSample.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebApiSample.BLL.Interfaces
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
		/// <returns>Результат добавления и Id.</returns>
		(RepositoryActionsResult repositoryActionResult, int employeeId) CreateEmployee(EmployeeEditModel employeeEditModel);

		/// <summary>
		/// Обновить сотрудника.
		/// </summary>
		/// <param name="employeeEditModel">Модель сотрудника.</param>
		/// <returns>Результат обновления и модель сотрудника.</returns>
		(RepositoryActionsResult repositoryActionResult, EmployeeViewModel employeeViewModel) UpdateEmployee(EmployeeEditModel employeeEditModel);

		/// <summary>
		/// Удалить сотрудника по Id.
		/// </summary>
		/// <param name="employeeId">Id сотрудника.</param>
		/// <returns>Результат удаления.</returns>
		RepositoryActionsResult DeleteEmployeeById(int employeeId);

		/// <summary>
		/// Получить сотрудника по Id.
		/// </summary>
		/// <param name="employeeId">Id сотрудника.</param>
		/// <returns>Результат поиска и модель.</returns>
		(RepositoryActionsResult repositoryActionResult, EmployeeViewModel employeeViewModel) GetEmployeeById(int employeeId);

		/// <summary>
		/// Получить всех сотрудников
		/// </summary>
		/// <param name="skip">Пропустить</param>
		/// <param name="take">Взять</param>
		/// <returns>Cписок сотрудников.</returns>
		IEnumerable<EmployeeViewModel> GetEmployees(int? skip = null, int? take = null);
	}
}
