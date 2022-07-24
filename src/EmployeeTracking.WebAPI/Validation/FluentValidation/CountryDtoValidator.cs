using EmployeeTracking.Dto.Concrete;
using FluentValidation;

namespace EmployeeTracking.WebAPI
{
    public class CountryDtoValidator : AbstractValidator<CountryDto>
    {
        public CountryDtoValidator()
        {
            RuleFor(c => c.Name).NotEmpty();
            RuleFor(c => c.Currency).NotEmpty().Length(3);
            RuleFor(c => c.Continent).NotEmpty();
            RuleFor(c => c.DepartmentId).NotEmpty();
            RuleFor(c => c.CreatedAt).NotEmpty();
        }
    }


}
