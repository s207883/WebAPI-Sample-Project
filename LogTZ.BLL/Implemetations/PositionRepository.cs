using AutoMapper;
using LogTZ.BLL.Interfaces;
using LogTZ.Core.EditModels;
using LogTZ.Core.Enums;
using LogTZ.Core.ViewModels;
using LogTZ.DAL;
using LogTZ.DAL.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogTZ.BLL.Implemetations
{
	public class PositionRepository : IPositionRepository
	{
		private readonly MainContext _mainContext;
		private readonly IMapper _mapper;

		public PositionRepository (MainContext mainContext, IMapper mapper)
		{
			_mainContext = mainContext;
			_mapper = mapper;
		}

		public RepositoryActionsResult DeletePositionById ( int positionId )
		{
			var position = _mainContext.Positions.FirstOrDefault(pos => pos.PositionId == positionId);

			var employeePositions = _mainContext.EmployeePositions.FirstOrDefault(ep => ep.PositionId == positionId);

			if ( position == default || employeePositions != default )
			{
				return RepositoryActionsResult.BadRequest;
			}
			else
			{
				_mainContext.Positions.Remove(position);
				_mainContext.SaveChanges();

				return RepositoryActionsResult.Success;
			}
		}

		public (RepositoryActionsResult repositoryActionsResult, PositionViewModel positionViewModel) GetPositionById ( int positionId )
		{
			var position = _mainContext.Positions.FirstOrDefault (pos => pos.PositionId == positionId );

			if ( position == default )
			{
				return (RepositoryActionsResult.BadRequest, default);
			}
			else
			{
				var positionViewModel = _mapper.Map<PositionViewModel>(position);

				return (RepositoryActionsResult.Success, positionViewModel);
			}
		}


		public (RepositoryActionsResult repositoryActionsResult, int positionId) CreatePosition ( PositionEditModel positionEditModel )
		{
			if ( positionEditModel is null || positionEditModel.Grade > 15 || positionEditModel.Grade < 0 )
			{
				return (RepositoryActionsResult.BadRequest, default);
			}

			var positionModel = _mapper.Map<Position> ( positionEditModel );

			_mainContext.Add ( positionModel );
			_mainContext.SaveChanges ( );

			return (RepositoryActionsResult.Success, positionModel.PositionId);
		}

		public (RepositoryActionsResult repositoryActionsResult, PositionViewModel positionViewModel) UpdatePosition ( PositionEditModel positionEditModel )
		{
			if ( positionEditModel is null || positionEditModel.Grade > 15 || positionEditModel.Grade < 0 )
			{
				return (RepositoryActionsResult.BadRequest, default);
			}

			var positionModel = _mapper.Map<Position> ( positionEditModel );
			var positionInDb = _mainContext.Positions.FirstOrDefault ( pos => pos.PositionId == positionModel.PositionId );

			if ( positionInDb == default )
			{
				return (RepositoryActionsResult.BadRequest, default);
			}
			else
			{
				positionInDb.Name = positionModel.Name;
				positionInDb.Grade = positionModel.Grade;

				_mainContext.SaveChanges ( );

				var positionViewModel = _mapper.Map<PositionViewModel>(positionInDb);
				return (RepositoryActionsResult.Success, positionViewModel);
			}
		}
	}
}
