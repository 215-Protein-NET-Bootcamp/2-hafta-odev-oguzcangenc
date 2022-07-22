using EmployeeTracking.Base.Response;
using EmployeeTracking.Data.Models;
using EmployeeTracking.Dto.Concrete;
using EmployeeTrancking.Dto;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace EmployeeTracking.Service.Abstract
{
    public interface IEmployeeService : IBaseService<EmployeeDto, Employee>
    {
        Task<BaseResponse<Employee>> GetEmployeeDetail(int id);
    }
}
