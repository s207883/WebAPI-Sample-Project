using AutoMapper;
using LogTZ.BLL.Interfaces;
using LogTZ.Core.Enums;
using LogTZ.DAL;
using LogTZ.DAL.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogTZ.BLL.Implemetations
{
	public class EployeePositionRepository : IEployeePositionRepository
	{
		private readonly MainContext _mainContext;

		public EployeePositionRepository (MainContext mainContext)
		{
			_mainContext = mainContext;
		}

		public RepositoryActionsResult RemovePositionFromEmployee ( int positionId, int employeeId )
		{
			var position = _mainContext.Positions.AsNoTracking().FirstOrDefault ( pos => pos.PositionId == positionId );
			var employee = _mainContext.Employees.AsNoTracking().FirstOrDefault ( emp => emp.EmployeeId == employeeId );

			if ( position == default || employee == default )
			{
				return RepositoryActionsResult.BadRequest;
			}
			else
			{
				var employeePosition = _mainContext.EmployeePositions
					.FirstOrDefault ( empPos => empPos.EmployeeId == employeeId && empPos.PositionId == positionId );

				if ( employeePosition != default )
				{
					_mainContext.EmployeePositions.Remove ( employeePosition );
					_mainContext.SaveChanges ( );

					return RepositoryActionsResult.Success;
				}
				else
				{
					return RepositoryActionsResult.BadRequest;
				}

			}
		}

		public RepositoryActionsResult SetPositionToEmployee ( int positionId, int employeeId )
		{
			var position = _mainContext.Positions.AsNoTracking().FirstOrDefault ( pos => pos.PositionId == positionId );
			var employee = _mainContext.Employees.AsNoTracking().FirstOrDefault ( emp => emp.EmployeeId == employeeId );

			var employeePositionInDb = _mainContext.EmployeePositions
				.FirstOrDefault ( emp => emp.EmployeeId == employeeId && emp.PositionId == positionId );

			if ( position == default || employee == default || employeePositionInDb != default )
			{
				return RepositoryActionsResult.BadRequest;
			}
			else
			{
				var employeePosition = new EmployeePosition
				{
					EmployeeId = employeeId,
					PositionId = positionId
				};

				_mainContext.EmployeePositions.Add ( employeePosition );
				_mainContext.SaveChanges ( );

				return RepositoryActionsResult.Success;
			}
		}
	}
}
