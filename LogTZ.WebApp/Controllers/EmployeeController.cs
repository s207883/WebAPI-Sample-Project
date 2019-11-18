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
	/// Контроллер сотрудников.
	/// </summary>
	[Route ( "api/[controller]" )]
	[ApiController]
	public class EmployeeController : ControllerBase
	{
		private readonly RepoManager _repoManager;

		public EmployeeController (RepoManager repoManager)
		{
			_repoManager = repoManager;
		}

		/// <summary>
		/// Получить сотрудника.
		/// </summary>
		/// <param name="employeeId">Id сотрудника.</param>
		/// <returns>Модель представления сотрудника.</returns>
		[HttpGet( "{employeeId}" )]
		public ActionResult<EmployeeViewModel> GetEmployee (int employeeId)
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

		/// <summary>
		/// Удалить сотрудника.
		/// </summary>
		/// <param name="employeeId">Id сотрудника.</param>
		[HttpDelete ( "{employeeId}" )]
		public ActionResult DeleteEmployee (int employeeId)
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

		/// <summary>
		/// Добавить сотрудника.
		/// </summary>
		/// <param name="employeeEditModel">Модель сотрудника.</param>
		[HttpPost]
		public ActionResult AddEmployee (EmployeeEditModel employeeEditModel)
		{
			if ( ModelState.IsValid )
			{
				var employee = _repoManager.EmployeeRepository.CreateEmployee ( employeeEditModel );

				if ( employee.repositoryActionResult == RepositoryActionsResult.Success )
				{
					return Ok ( new { Id = employee.employeeId } );
				}
				else
				{
					return BadRequest ( employee.repositoryActionResult );
				}
			}
			else
			{
				return BadRequest(employeeEditModel);
			}
		}

		/// <summary>
		/// Изменить сотрудника.
		/// </summary>
		/// <param name="employeeEditModel">Модель сотрудника.</param>
		[HttpPut]
		public ActionResult<EmployeeViewModel> UpdateEmployee (EmployeeEditModel employeeEditModel)
		{
			if ( ModelState.IsValid )
			{
				var result = _repoManager.EmployeeRepository.UpdateEmployee ( employeeEditModel );

				if ( result.repositoryActionResult == RepositoryActionsResult.Success )
				{
					return Ok ( result.employeeViewModel );
				}
				else
				{
					return BadRequest ( result.repositoryActionResult );
				}
			}
			else
			{
				return BadRequest(employeeEditModel);
			}
		}

	}
}