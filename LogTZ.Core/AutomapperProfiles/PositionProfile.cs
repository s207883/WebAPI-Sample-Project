using AutoMapper;
using LogTZ.Core.EditModels;
using LogTZ.Core.ViewModels;
using LogTZ.DAL.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogTZ.Core.AutomapperProfiles
{
	/// <summary>
	/// Профиль должности для AutoMapper.
	/// </summary>
	public class PositionProfile : Profile
	{
		public PositionProfile()
		{
			CreateMap<Position, PositionViewModel>().ReverseMap();
			CreateMap<Position, PositionEditModel>().ReverseMap();
		}
	}
}
