using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiSample.BLL;
using WebApiSample.Core.EditModels;
using WebApiSample.Core.Enums;
using WebApiSample.Core.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApiSample.WebApp.Controllers
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
		/// <response code="200">Возвращает сотрудника.</response>
		/// <response code="400">Если не удалось найти сотрудника.</response>   
		/// <returns>Модель представления сотрудника.</returns>
		[HttpGet ( "{employeeId}" )]
		public ActionResult<EmployeeViewModel> GetEmployee (int employeeId)
		{
			var employee = _repoManager.EmployeeRepository.GetEmployeeById ( employeeId );
			if ( employee.repositoryActionResult == RepositoryActionsResult.Success )
			{
				return Ok ( employee.employeeViewModel );
			}
			else
			{
				return BadRequest ();
			}
		}

		/// <summary>
		/// Удалить сотрудника.
		/// </summary>
		/// <response code="200">При успешном удалении сотрудника.</response>
		/// <response code="400">Если не удалось удалить сотрудника.</response>   
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
				return BadRequest();
			}
		}

		/// <summary>
		/// Добавить сотрудника.
		/// </summary>
		/// <response code="201">Возвращает Id нового сотрудника.</response>
		/// <response code="400">Если не удалось добавить сотрудника.</response>   
		/// <param name="employeeEditModel">Модель сотрудника.</param>
		[HttpPost]
		public ActionResult AddEmployee (EmployeeEditModel employeeEditModel)
		{
			if ( ModelState.IsValid )
			{
				var employee = _repoManager.EmployeeRepository.CreateEmployee ( employeeEditModel );

				if ( employee.repositoryActionResult == RepositoryActionsResult.Success )
				{
					return CreatedAtAction (nameof(AddEmployee), new { Id = employee.employeeId } );
				}
				else
				{
					return BadRequest ();
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
		/// <response code="200">Возвращает модель сотрудника.</response>
		/// <response code="400">Если не удалось обновить сотрудника.</response>   
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
					return BadRequest ();
				}
			}
			else
			{
				return BadRequest(employeeEditModel);
			}
		}

	}
}