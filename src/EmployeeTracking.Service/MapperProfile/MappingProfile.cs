using AutoMapper;
using EmployeeTracking.Data.Models;
using EmployeeTracking.Dto.Concrete;
using EmployeeTrancking.Dto;

namespace EmployeeTracking.Service.MapperProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, EmployeeDto>().ReverseMap();
            CreateMap<Folder, FolderDto>().ReverseMap();
            CreateMap<Country, CountryDto>().ReverseMap();
            CreateMap<Department, DepartmentDto>().ReverseMap();
            CreateMap<Department, DepartmentAddDto>().ReverseMap();
        }
    }
}
