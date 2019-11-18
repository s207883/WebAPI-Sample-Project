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
			///TODO: Добавить проверку, что должность не занята.
			var position = _mainContext.Positions.FirstOrDefault();

			if ( position == default )
			{
				return RepositoryActionsResult.DadData;
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
				return (RepositoryActionsResult.Fail, default);
			}
			else
			{
				var positionViewModel = _mapper.Map<PositionViewModel>(position);

				return (RepositoryActionsResult.Success, positionViewModel);
			}
		}


		public (RepositoryActionsResult repositoryActionsResult, int positionId) CreatePosition ( PositionEditModel positionEditModel )
		{
			if ( positionEditModel is null )
			{
				return (RepositoryActionsResult.DadData, default);
			}

			var positionModel = _mapper.Map<Employee> ( positionEditModel );

			_mainContext.Add ( positionModel );
			_mainContext.SaveChanges ( );

			return (RepositoryActionsResult.Success, positionModel.EmployeeId);
		}

		public (RepositoryActionsResult repositoryActionsResult, PositionViewModel positionViewModel) UpdatePosition ( PositionEditModel positionEditModel )
		{
			if ( positionEditModel is null )
			{
				return (RepositoryActionsResult.DadData, default);
			}

			var positionModel = _mapper.Map<Position> ( positionEditModel );
			var positionInDb = _mainContext.Positions.FirstOrDefault ( pos => pos.PositionId == positionModel.PositionId );

			if ( positionInDb == default )
			{
				return (RepositoryActionsResult.DadData, default);
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
