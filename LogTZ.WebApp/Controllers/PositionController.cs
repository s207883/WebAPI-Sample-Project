using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LogTZ.BLL;
using LogTZ.Core.EditModels;
using LogTZ.Core.Enums;
using LogTZ.Core.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LogTZ.WebApp.Controllers
{
	/// <summary>
	/// Контроллер должностей.
	/// </summary>
	[Route ( "api/[controller]" )]
	[ApiController]
	public class PositionController : ControllerBase
	{
		private readonly RepoManager _repoManager;

		public PositionController (RepoManager repoManager)
		{
			_repoManager = repoManager;
		}

		/// <summary>
		/// Добавить должность.
		/// </summary>
		/// <param name="positionEditModel">Модель должности.</param>
		/// <response code="201">Возвращает Id новой должности.</response>
		/// <response code="400">Если не удалось добавить должность.</response>   
		/// <returns>Id должности.</returns>
		[HttpPost]
		public ActionResult<int> AddPosition (PositionEditModel positionEditModel)
		{
			if ( ModelState.IsValid )
			{
				var result = _repoManager.PositionRepository.CreatePosition ( positionEditModel );

				if ( result.repositoryActionsResult == RepositoryActionsResult.Success )
				{
					return CreatedAtAction ( nameof ( AddPosition ),new { Id = result.positionId } );
				}
				else
				{
					return BadRequest ();
				}
			}
			else
			{
				return BadRequest(positionEditModel);
			}
		}

		/// <summary>
		/// Получить должность.
		/// </summary>
		/// <param name="positionId">Id должности.</param>
		/// <response code="200">Возвращает должность.</response>
		/// <response code="400">Если не удалось найти должность.</response> 
		/// <returns>Модель должности.</returns>
		[HttpGet ( "{positionId}")]
		public ActionResult<PositionViewModel> GetPosition (int positionId)
		{
			var result = _repoManager.PositionRepository.GetPositionById(positionId);

			if ( result.repositoryActionsResult == RepositoryActionsResult.Success )
			{
				return Ok(result.positionViewModel);
			}
			else
			{
				return BadRequest();
			}
		}

		/// <summary>
		/// Обновить должность.
		/// </summary>
		/// <param name="positionEditModel">Модель должности.</param>
		/// <response code="200">Возвращает должность.</response>
		/// <response code="400">Если не удалось обновить должность.</response> 
		/// <returns>Обновленную модель должности.</returns>
		[HttpPut]
		public ActionResult<PositionViewModel> UpdatePosition (PositionEditModel positionEditModel)
		{
			if ( ModelState.IsValid )
			{
				var result = _repoManager.PositionRepository.UpdatePosition ( positionEditModel );

				if ( result.repositoryActionsResult == RepositoryActionsResult.Success )
				{
					return Ok ( result.positionViewModel );
				}
				else
				{
					return BadRequest ();
				}
			}
			else
			{
				return BadRequest(positionEditModel);
			}
		}

		/// <summary>
		/// Удалить должность.
		/// </summary>
		/// <response code="200">Если удалось удалить должность.</response>
		/// <response code="400">Если не удалось удалить должность.</response> 
		/// <param name="positionId">Id должности.</param>
		[HttpDelete ( "{positionId}" )]
		public ActionResult DeletePosition (int positionId)
		{
			var result = _repoManager.PositionRepository.DeletePositionById(positionId);

			if ( result == RepositoryActionsResult.Success )
			{
				return Ok();
			}
			else
			{
				return BadRequest();
			}
		}


	}
}