using EmployeeTracking.Dto.Concrete;
using FluentValidation;

namespace EmployeeTracking.WebAPI
{
    public class FolderDtoValidator : AbstractValidator<FolderDto>
    {
        public FolderDtoValidator()
        {
            RuleFor(f => f.AccessType).NotEmpty();
        }
    }    


}
