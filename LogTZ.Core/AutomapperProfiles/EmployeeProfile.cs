using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using LogTZ.Core.EditModels;
using LogTZ.Core.ViewModels;
using LogTZ.DAL.Model;

namespace LogTZ.Core.AutomapperProfiles
{
	/// <summary>
	/// Профиль сотрудника.
	/// </summary>
	public class EmployeeProfile : Profile
	{
		public EmployeeProfile ( )
		{
			CreateMap<EmployeeEditModel, Employee>().ReverseMap();
			CreateMap<EmployeeViewModel, Employee>().ReverseMap();
		}
	}
}
