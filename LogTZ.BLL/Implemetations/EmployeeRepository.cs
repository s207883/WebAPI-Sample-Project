using AutoMapper;
using LogTZ.BLL.Interfaces;
using LogTZ.Core.EditModels;
using LogTZ.Core.Enums;
using LogTZ.Core.ViewModels;
using LogTZ.DAL;
using LogTZ.DAL.Model;
using System.Collections.Generic;
using System.Linq;

namespace LogTZ.BLL.Implemetations
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

			var employeePosition = _mainContext.EmployeePositions.FirstOrDefault(emp => emp.EmployeeId == employeeId);

			if ( employeeInDb == default || employeePosition != default)
			{
				return RepositoryActionsResult.DadData;
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
			var employeeModel = _mainContext.Employees.FirstOrDefault ( emp => emp.EmployeeId == employeeId );

			if ( employeeModel == default )
			{
				return (RepositoryActionsResult.DadData, default);
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
				return (RepositoryActionsResult.DadData, default);
			}

			var employeeModel = _mapper.Map<Employee> ( employeeEditModel );

			_mainContext.Add ( employeeModel );
			_mainContext.SaveChanges ( );

			return (RepositoryActionsResult.Success, employeeModel.EmployeeId);
		}

		public (RepositoryActionsResult repositoryActionResult, EmployeeViewModel employeeViewModel) UpdateEmployee ( EmployeeEditModel employeeEditModel )
		{
			if ( employeeEditModel is null )
			{
				return (RepositoryActionsResult.DadData, null);
			}

			var employeeModel = _mapper.Map<Employee> ( employeeEditModel );

			var employeeInDb = _mainContext.Employees.FirstOrDefault ( emp => emp.EmployeeId == employeeModel.EmployeeId );

			if ( employeeInDb == default )
			{
				return (RepositoryActionsResult.DadData, null);
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
			var employeePositions = _mainContext.EmployeePositions.Where ( p => p.EmployeeId == employeeViewModel.EmployeeId ).ToList ( );

			var employeePositionsViewModel = _mapper.Map<IEnumerable<EmployeePositionViewModel>> ( employeePositions );

			foreach ( var emPos in employeePositionsViewModel )
			{
				var position = _mainContext.Positions.FirstOrDefault ( pos => pos.PositionId == emPos.PositionId );
				emPos.Name = position.Name;
				emPos.Grade = position.Grade;
			}

			employeeViewModel.Positions = employeePositionsViewModel;
			return employeeViewModel;
		}
	}
}
