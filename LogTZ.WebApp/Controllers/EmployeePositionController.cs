using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LogTZ.BLL;
using LogTZ.Core.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LogTZ.WebApp.Controllers
{
	[Route ( "api/[controller]" )]
	[ApiController]
	public class EmployeePositionController : ControllerBase
	{
		//TODO: Документация.
		private readonly RepoManager _repoManager;

		public EmployeePositionController (RepoManager repoManager)
		{
			_repoManager = repoManager;
		}

		[HttpPost]
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

		[HttpDelete]
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