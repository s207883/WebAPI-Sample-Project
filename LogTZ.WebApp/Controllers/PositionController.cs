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
	[Route ( "api/[controller]" )]
	[ApiController]
	public class PositionController : ControllerBase
	{
		private readonly RepoManager _repoManager;

		public PositionController (RepoManager repoManager)
		{
			_repoManager = repoManager;
		}

		[HttpPost]
		public ActionResult AddPosition (PositionEditModel positionEditModel)
		{
			var result = _repoManager.PositionRepository.CreatePosition(positionEditModel);

			if ( result.repositoryActionsResult == RepositoryActionsResult.Success )
			{
				return Ok(result.positionId);
			}
			else
			{
				return BadRequest(result.repositoryActionsResult);
			}
		}

		// GET: api/Position/5
		[HttpGet]
		public ActionResult<PositionViewModel> GetPosition (int positionId)
		{
			var result = _repoManager.PositionRepository.GetPositionById(positionId);

			if ( result.repositoryActionsResult == RepositoryActionsResult.Success )
			{
				return Ok(result.positionViewModel);
			}
			else
			{
				return BadRequest(result.repositoryActionsResult);
			}
		}

		// PUT: api/Position
		[HttpPut]
		public ActionResult<PositionViewModel> UpdatePosition (PositionEditModel positionEditModel)
		{
			var result = _repoManager.PositionRepository.UpdatePosition(positionEditModel);

			if ( result.repositoryActionsResult == RepositoryActionsResult.Success )
			{
				return Ok(result.positionViewModel);
			}
			else
			{
				return BadRequest(result.repositoryActionsResult);
			}
		}

		// DELETE: api/Position/5
		[HttpDelete]
		public ActionResult DeletePosition (int positionId)
		{
			var result = _repoManager.PositionRepository.DeletePositionById(positionId);

			if ( result == RepositoryActionsResult.Success )
			{
				return Ok();
			}
			else
			{
				return BadRequest(result);
			}
		}


	}
}