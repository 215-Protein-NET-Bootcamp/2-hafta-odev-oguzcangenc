using AutoMapper;
using EmployeeTracking.Base.Response;
using EmployeeTracking.Data.Models;
using EmployeeTracking.Data.Repositories;
using EmployeeTracking.Data.Repositories.Abstarct;
using EmployeeTracking.Dto.Concrete;
using EmployeeTracking.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTracking.Service.Concrete
{
    public class DepartmentService : BaseService<DepartmentDto, Department>, IDepartmentService
    {
        public DepartmentService(IDepartmentRepository departmentRepository, IMapper mapper, IUnitOfWork unitOfWork) : base(departmentRepository, mapper, unitOfWork)
        {
        }
    }
}
