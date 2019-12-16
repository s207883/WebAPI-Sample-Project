using WebApiSample.Core.EditModels;
using WebApiSample.Core.Enums;
using WebApiSample.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebApiSample.BLL.Interfaces
{
	/// <summary>
	/// Интерфейс репозитория должностей.
	/// </summary>
	public interface IPositionRepository
	{
		/// <summary>
		/// Создать должность.
		/// </summary>
		/// <param name="positionEditModel">Модель должности.</param>
		/// <returns>Результат добавления и Id.</returns>
		(RepositoryActionsResult repositoryActionsResult, int positionId) CreatePosition(PositionEditModel positionEditModel);

		/// <summary>
		/// Обновить должность.
		/// </summary>
		/// <param name="positionEditModel">Модель должности.</param>
		/// <returns>Результат обновления и новую модель.</returns>
		(RepositoryActionsResult repositoryActionsResult, PositionViewModel positionViewModel) UpdatePosition(PositionEditModel positionEditModel);

		/// <summary>
		/// Удалить должность по Id.
		/// </summary>
		/// <param name="positionId">Id должности.</param>
		/// <returns>Результат удаления.</returns>
		RepositoryActionsResult DeletePositionById(int positionId);

		/// <summary>
		/// Получить должность по Id.
		/// </summary>
		/// <param name="positionId">Id должности.</param>
		/// <returns>Результат и модель.</returns>
		(RepositoryActionsResult repositoryActionsResult, PositionViewModel positionViewModel) GetPositionById(int positionId);
	}
}
