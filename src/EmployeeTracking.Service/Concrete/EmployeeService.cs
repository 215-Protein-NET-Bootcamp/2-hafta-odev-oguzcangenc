using AutoMapper;
using EmployeeTracking.Base;
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
            try
            {
                var tempEntity = await _employeeRepository.GetByIdEmployeeDetailAsync(id);
                // Mapping Entity to Resource

                if (tempEntity == null)
                {
                    return new BaseResponse<Employee>(false);
                }
            }
            catch (Exception ex)
            {

                throw new MessageResultException("Id_NoData", ex);

            }
            return new BaseResponse<Employee>(await _employeeRepository.GetByIdEmployeeDetailAsync(id));
        }
    }
}
