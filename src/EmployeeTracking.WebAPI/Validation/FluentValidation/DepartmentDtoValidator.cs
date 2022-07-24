using EmployeeTracking.Dto.Concrete;
using FluentValidation;

namespace EmployeeTracking.WebAPI
{
    public class DepartmentDtoValidator : AbstractValidator<DepartmentDto>
    {
        public DepartmentDtoValidator()
        {
            RuleFor(d => d.Name).NotEmpty();
            RuleFor(d => d.CreatedAt).NotEmpty();
           
        }
    }


}
