using AutoMapper;
using WebApiSample.BLL.Interfaces;
using WebApiSample.Core.EditModels;
using WebApiSample.Core.Enums;
using WebApiSample.Core.ViewModels;
using WebApiSample.DAL;
using WebApiSample.DAL.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace WebApiSample.BLL.Implemetations
{
	public class EmployeeRepository : IEmployeeRepository
	{
		private readonly MainContext _mainContext;
		private readonly IMapper _mapper;

		public EmployeeRepository ( MainContext mainContext, IMapper mapper )
		{
			_mainContext = mainContext;
			_mapper = mapper;
		}

		public RepositoryActionsResult DeleteEmployeeById ( int employeeId )
		{
			var employeeInDb = _mainContext.Employees.FirstOrDefault ( emp => emp.EmployeeId == employeeId );

			var employeePosition = _mainContext.EmployeePositions
				.AsNoTracking()
				.FirstOrDefault(emp => emp.EmployeeId == employeeId);

			if ( employeeInDb == default || employeePosition != default)
			{
				return RepositoryActionsResult.BadRequest;
			}
			else
			{
				_mainContext.Employees.Remove ( employeeInDb );
				_mainContext.SaveChanges ( );

				return RepositoryActionsResult.Success;
			}
		}

		public (RepositoryActionsResult repositoryActionResult, EmployeeViewModel employeeViewModel) GetEmployeeById ( int employeeId )
		{
			var employeeModel = _mainContext.Employees
				.AsNoTracking()
				.FirstOrDefault ( emp => emp.EmployeeId == employeeId );

			if ( employeeModel == default )
			{
				return (RepositoryActionsResult.BadRequest, default);
			}
			else
			{
				EmployeeViewModel employeeViewModel = GetEmployeeViewModel ( employeeModel );
				return (RepositoryActionsResult.Success, employeeViewModel);
			}
		}

		public (RepositoryActionsResult repositoryActionResult, int employeeId) CreateEmployee ( EmployeeEditModel employeeEditModel )
		{
			if ( employeeEditModel is null )
			{
				return (RepositoryActionsResult.BadRequest, default);
			}

			var employeeModel = _mapper.Map<Employee> ( employeeEditModel );

			employeeModel.EmployeeId = default;

			_mainContext.Add ( employeeModel );
			_mainContext.SaveChanges ( );

			return (RepositoryActionsResult.Success, employeeModel.EmployeeId);
		}

		public (RepositoryActionsResult repositoryActionResult, EmployeeViewModel employeeViewModel) UpdateEmployee ( EmployeeEditModel employeeEditModel )
		{
			if ( employeeEditModel is null )
			{
				return (RepositoryActionsResult.BadRequest, null);
			}

			var employeeModel = _mapper.Map<Employee> ( employeeEditModel );

			var employeeInDb = _mainContext.Employees.FirstOrDefault ( emp => emp.EmployeeId == employeeModel.EmployeeId );

			if ( employeeInDb == default )
			{
				return (RepositoryActionsResult.BadRequest, null);
			}
			else
			{
				employeeInDb.Name = employeeModel.Name;
				employeeInDb.BirthDate = employeeInDb.BirthDate;

				_mainContext.SaveChanges ( );

				EmployeeViewModel employeeViewModel = GetEmployeeViewModel ( employeeInDb );

				return (RepositoryActionsResult.Success, employeeViewModel);
			}
		}

		private EmployeeViewModel GetEmployeeViewModel ( Employee employeeInDb )
		{
			var employeeViewModel = _mapper.Map<EmployeeViewModel> ( employeeInDb );
			var employeePositions = _mainContext.EmployeePositions
				.AsNoTracking()
				.Include(emp=> emp.Position)
				.Where ( p => p.EmployeeId == employeeViewModel.EmployeeId )
				.ToList ( );

			var employeePositionsViewModel = _mapper.Map<IEnumerable<EmployeePositionViewModel>> ( employeePositions );

			foreach ( var emPos in employeePositionsViewModel )
			{
				var position = employeePositions.FirstOrDefault ( pos => pos.PositionId == emPos.PositionId );
				emPos.Name = position.Position.Name;
				emPos.Grade = position.Position.Grade;
			}

			employeeViewModel.Positions = employeePositionsViewModel;
			return employeeViewModel;
		}
	}
}
