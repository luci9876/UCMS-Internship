using AutoMapper;
using HrApi.DTO;
using HrApi.Models;


namespace HrApi.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Company, CompanyDTO>().ReverseMap();

            CreateMap<Employee, EmployeeDTO>().ReverseMap();
           

        }
    }
}