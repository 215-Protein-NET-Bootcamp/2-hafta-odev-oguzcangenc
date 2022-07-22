using AutoMapper;
using EmployeeTracking.Base.Response;
using EmployeeTracking.Data.Models;
using EmployeeTracking.Data.Repositories;
using EmployeeTracking.Data.Repositories.Abstarct;
using EmployeeTracking.Dto.Concrete;
using EmployeeTracking.Service.Abstract;
using EmployeeTrancking.Dto;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace EmployeeTracking.Service.Concrete
{
    public class EmployeeService : BaseService<EmployeeDto,Employee>, IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper, IUnitOfWork unitOfWork) : base(employeeRepository, mapper, unitOfWork)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<BaseResponse<Employee>> GetEmployeeDetail(int id)
        {
            return new BaseResponse<Employee>(await _employeeRepository.GetByIdEmployeeDetailAsync(id));
        }
    }
}
