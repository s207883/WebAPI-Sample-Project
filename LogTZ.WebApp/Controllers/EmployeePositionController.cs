﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LogTZ.BLL;
using LogTZ.Core.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LogTZ.WebApp.Controllers
{
	/// <summary>
	/// Контроллер должностей сотрудников.
	/// </summary>
	[Route ( "api/[controller]" )]
	[ApiController]
	public class EmployeePositionController : ControllerBase
	{
		private readonly RepoManager _repoManager;

		public EmployeePositionController (RepoManager repoManager)
		{
			_repoManager = repoManager;
		}

		/// <summary>
		/// Добавить сотруднику должность.
		/// </summary>
		/// <param name="positionId">Id должности.</param>
		/// <param name="employeeId">Id сотрудника.</param>
		[HttpPost ("{positionId}, {employeeId}" )]
		public ActionResult SetPositionToEmployee (int positionId, int employeeId)
		{
			var result = _repoManager.EployeePositionRepository.SetPositionToEmployee(positionId,employeeId);

			if ( result == RepositoryActionsResult.Success )
			{
				return Ok();
			}
			else
			{
				return BadRequest(result);
			}
		}

		/// <summary>
		/// Снимает сотрудника с должности.
		/// </summary>
		/// <param name="positionId">Id должности.</param>
		/// <param name="employeeId">Id сотрудника.</param>
		[HttpDelete ("{positionId}, {employeeId}" )]
		public ActionResult RemovePositionFromEmployee (int positionId, int employeeId)
		{
			var result = _repoManager.EployeePositionRepository.RemovePositionFromEmployee ( positionId, employeeId );

			if ( result == RepositoryActionsResult.Success )
			{
				return Ok ( );
			}
			else
			{
				return BadRequest ( result );
			}
		}

	}
}