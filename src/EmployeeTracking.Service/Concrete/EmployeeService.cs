using AutoMapper;
using EmployeeTracking.Data.Models;
using EmployeeTracking.Data.Repositories;
using EmployeeTracking.Data.Repositories.Abstarct;
using EmployeeTracking.Service.Abstract;
using EmployeeTrancking.Dto;

namespace EmployeeTracking.Service.Concrete
{
    public class EmployeeService : BaseService<EmloyeeDto,Employee>, IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper, IUnitOfWork unitOfWork) : base(employeeRepository, mapper, unitOfWork)
        {
            _employeeRepository = employeeRepository;
        }
    }
}
