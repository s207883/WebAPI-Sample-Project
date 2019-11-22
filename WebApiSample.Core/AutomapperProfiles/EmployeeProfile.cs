using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using WebApiSample.Core.EditModels;
using WebApiSample.Core.ViewModels;
using WebApiSample.DAL.Model;

namespace WebApiSample.Core.AutomapperProfiles
{
	/// <summary>
	/// Профиль сотрудника для AutoMapper
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
