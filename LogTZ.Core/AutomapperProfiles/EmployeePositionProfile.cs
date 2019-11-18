using AutoMapper;
using LogTZ.Core.EditModels;
using LogTZ.Core.ViewModels;
using LogTZ.DAL.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogTZ.Core.AutomapperProfiles
{
	public class EmployeePositionProfile : Profile
	{
		public EmployeePositionProfile ( )
		{
			CreateMap<EmployeePosition, EmployeePositionViewModel>().ReverseMap();
			CreateMap<EmployeePosition, EmployeePositionEditModel>().ReverseMap();
		}
	}
}
