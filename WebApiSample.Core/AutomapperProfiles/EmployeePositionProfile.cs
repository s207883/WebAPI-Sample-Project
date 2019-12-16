using AutoMapper;
using WebApiSample.Core.EditModels;
using WebApiSample.Core.ViewModels;
using WebApiSample.DAL.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebApiSample.Core.AutomapperProfiles
{
	public class EmployeePositionProfile : Profile
	{
		/// <summary>
		/// Профиль должности сотрудника для AutoMapper
		/// </summary>
		public EmployeePositionProfile()
		{
			CreateMap<EmployeePosition, EmployeePositionViewModel>().ReverseMap();
			CreateMap<EmployeePosition, EmployeePositionEditModel>().ReverseMap();
		}
	}
}
