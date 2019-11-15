using AutoMapper;
using LogTZ.BLL.Interfaces;
using LogTZ.Core.Enums;
using LogTZ.DAL;
using LogTZ.DAL.Model;
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
			var position = _mainContext.Positions.FirstOrDefault ( pos => pos.PositionId == positionId );
			var employee = _mainContext.Employees.FirstOrDefault ( emp => emp.EmployeeId == employeeId );

			if ( position == default || employee == default )
			{
				return RepositoryActionsResult.DadData;
			}
			else
			{
				var employeePosition = _mainContext.EployeePositions
					.FirstOrDefault ( empPos => empPos.EmployeeId == employeeId && empPos.PositionId == positionId );

				_mainContext.EployeePositions.Remove ( employeePosition );
				_mainContext.SaveChanges();

				return RepositoryActionsResult.Success;
			}
		}

		public RepositoryActionsResult SetPositionToEmployee ( int positionId, int employeeId )
		{
			var position = _mainContext.Positions.FirstOrDefault ( pos => pos.PositionId == positionId );
			var employee = _mainContext.Employees.FirstOrDefault ( emp => emp.EmployeeId == employeeId );

			if ( position == default || employee == default )
			{
				return RepositoryActionsResult.DadData;
			}
			else
			{
				var employeePosition = new EployeePosition
				{
					EmployeeId = employeeId,
					PositionId = positionId
				};

				_mainContext.EployeePositions.Add ( employeePosition );
				_mainContext.SaveChanges ( );

				return RepositoryActionsResult.Success;
			}
		}
	}
}
