using LogTZ.Core.EditModels;
using LogTZ.Core.Enums;
using LogTZ.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogTZ.BLL.Interfaces
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
		/// <returns>Результат добавления.</returns>
		RepositoryActionsResult CreatePosition ( PositionEditModel positionEditModel );

		/// <summary>
		/// Обновить должность.
		/// </summary>
		/// <param name="positionEditModel">Модель должности.</param>
		/// <returns>Результат обновления.</returns>
		RepositoryActionsResult UpdatePosition ( PositionEditModel positionEditModel );

		/// <summary>
		/// Удалить должность по Id.
		/// </summary>
		/// <param name="positionId">Id должности.</param>
		/// <returns>Результат удаления.</returns>
		RepositoryActionsResult DeletePositionById ( int positionId );

		/// <summary>
		/// Получить должность по Id.
		/// </summary>
		/// <param name="positionId">Id должности.</param>
		/// <returns>Результат и модель.</returns>
		(RepositoryActionsResult repositoryActionsResult, PositionViewModel positionViewModel) GetPositionById ( int positionId );
	}
}
