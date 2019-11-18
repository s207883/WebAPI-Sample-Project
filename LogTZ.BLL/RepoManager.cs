using LogTZ.BLL.Interfaces;

namespace LogTZ.BLL
{
	/// <summary>
	/// Менеджер данных.
	/// </summary>
	public class RepoManager
	{
		private readonly IEmployeeRepository _employeeRepository;
		private readonly IEployeePositionRepository _eployeePositionRepository;
		private readonly IPositionRepository _positionRepository;


		public IEmployeeRepository EmployeeRepository => _employeeRepository;
		public IPositionRepository PositionRepository => _positionRepository;
		public IEployeePositionRepository EployeePositionRepository => _eployeePositionRepository;

		/// <summary>
		/// Конструктор.
		/// </summary>
		/// <param name="employeeRepository">Реализация репозитория сотрудников.</param>
		/// <param name="positionRepository">Реализация репозитория должности.</param>
		/// <param name="eployeePositionRepository">Реализация репозитория должностей сотрудников.</param>
		public RepoManager(
			IEmployeeRepository employeeRepository, IPositionRepository positionRepository, IEployeePositionRepository eployeePositionRepository)
		{
			_employeeRepository = employeeRepository;
			_positionRepository = positionRepository;
			_eployeePositionRepository = eployeePositionRepository;
		}
	}
}
