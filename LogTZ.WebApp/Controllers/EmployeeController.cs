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
	public class EmployeeController : ControllerBase
	{
		private readonly RepoManager _repoManager;

		public EmployeeController (RepoManager repoManager)
		{
			_repoManager = repoManager;
		}

		// GET: api/Employee/5
		[HttpGet]
		public ActionResult<EmployeeViewModel> GetEmployee ([FromQuery]int employeeId)
		{
			var employee = _repoManager.EmployeeRepository.GetEmployeeById ( employeeId );
			if ( employee.repositoryActionResult == RepositoryActionsResult.Success )
			{
				return Ok ( employee.employeeViewModel );
			}
			else
			{
				return BadRequest ( employee.repositoryActionResult );
			}
		}

		// DELETE: api/Employee/5
		[HttpDelete]
		public ActionResult DeleteEmployee ([FromQuery] int employeeId)
		{
			var result = _repoManager.EmployeeRepository.DeleteEmployeeById ( employeeId );
			if ( result == RepositoryActionsResult.Success )
			{
				return Ok();
			}
			else
			{
				return BadRequest(result);
			}
		}

		// POST: api/Employee
		[HttpPost]
		public ActionResult AddEmployee ([FromQuery] EmployeeEditModel employeeEditModel)
		{
			var employee = _repoManager.EmployeeRepository.CreateEmployee(employeeEditModel);

			if ( employee.repositoryActionResult == RepositoryActionsResult.Success )
			{
				return Ok(new { Id = employee.employeeId});
			}
			else
			{
				return BadRequest(employee.repositoryActionResult);
			}
		}

		// PUT: api/Employee
		[HttpPut]
		public ActionResult<EmployeeViewModel> UpdateEmployee ([FromQuery] EmployeeEditModel employeeEditModel)
		{
			var result = _repoManager.EmployeeRepository.UpdateEmployee(employeeEditModel);

			if ( result.repositoryActionResult == RepositoryActionsResult.Success )
			{
				return Ok(result.employeeViewModel);
			}
			else
			{
				return BadRequest(result.repositoryActionResult);
			}
		}

	}
}