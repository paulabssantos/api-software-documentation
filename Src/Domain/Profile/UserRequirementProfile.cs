namespace api_software_documentation.src.Domain.Profile;

using api_software_documentation.Migrations;
using api_software_documentation.src.Domain.Dtos;
using api_software_documentation.Src.Domain.Entities;
using AutoMapper;
public class UserRequirementProfile : Profile
{
    public UserRequirementProfile()
    {
        CreateMap<CreateUserRequirementDto, UserRequirement>();
        CreateMap<UserRequirement, ReadUserRequirementDto>();
    }

}
