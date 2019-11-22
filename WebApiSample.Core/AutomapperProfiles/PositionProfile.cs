using AutoMapper;
using WebApiSample.Core.EditModels;
using WebApiSample.Core.ViewModels;
using WebApiSample.DAL.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebApiSample.Core.AutomapperProfiles
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
