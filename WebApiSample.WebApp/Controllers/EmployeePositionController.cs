using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiSample.BLL;
using WebApiSample.Core.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApiSample.WebApp.Controllers
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
		/// <response code="201">При добавлении должности сотруднику.</response>
		/// <response code="400">Если не удалось добавить должность сотруднику.</response>   
		[HttpPost ("{positionId}, {employeeId}" )]
		public ActionResult SetPositionToEmployee (int positionId, int employeeId)
		{
			var result = _repoManager.EployeePositionRepository.SetPositionToEmployee(positionId,employeeId);

			if ( result == RepositoryActionsResult.Success )
			{
				return CreatedAtAction(nameof(SetPositionToEmployee), new { PositionId = positionId, EmployeeId = employeeId});
			}
			else
			{
				return BadRequest();
			}
		}

		/// <summary>
		/// Снимает сотрудника с должности.
		/// </summary>
		/// <param name="positionId">Id должности.</param>
		/// <param name="employeeId">Id сотрудника.</param>
		/// <response code="200">При снятии сотрудника с должности.</response>
		/// <response code="400">Если не удалось снять сотрудника с должности.</response>   
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
				return BadRequest ();
			}
		}

	}
}