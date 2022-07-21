using AutoMapper;
using EmployeeTracking.Data.Models;
using EmployeeTrancking.Dto;

namespace EmployeeTracking.Service.MapperProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, EmloyeeDto>().ReverseMap();
        }
    }
}
