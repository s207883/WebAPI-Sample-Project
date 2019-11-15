using LogTZ.Core.EditModels;
using LogTZ.Core.Enums;
using LogTZ.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogTZ.BLL.Interfaces
{
	public interface IEmployeeRepository
	{
		RepositoryActionsResult Create ( EmployeeEditModel employeeEditModel);
		RepositoryActionsResult Delete ( int employeeId );
		(RepositoryActionsResult repositoryActionResult, EmployeeViewModel employeeViewModel) GetEmployeeById ( int employeeId );
		RepositoryActionsResult UpdateEmployee ( EmployeeEditModel employeeEditModel );
	}
}
