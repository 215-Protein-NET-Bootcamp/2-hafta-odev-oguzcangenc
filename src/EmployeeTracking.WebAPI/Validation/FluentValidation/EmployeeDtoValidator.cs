using EmployeeTracking.Base.BaseModel;
using EmployeeTrancking.Dto;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTracking.WebAPI
{
    public class EmployeeDtoValidator: AbstractValidator<EmployeeDto>
    {
        public EmployeeDtoValidator()
        {
            RuleFor(e => e.Name).NotEmpty();
            RuleFor(e => e.DepartmentId).NotEmpty();
        
        }
    }


}
