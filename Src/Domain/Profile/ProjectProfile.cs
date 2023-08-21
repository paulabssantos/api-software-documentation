namespace api_software_documentation.src.Domain.Profile;

using api_software_documentation.src.Domain.Dtos;
using api_software_documentation.src.Domain.Entities;
using api_software_documentation.Src.Domain.Dtos;
using AutoMapper;
public class ProjectProfile : Profile
{
    public ProjectProfile()
    {
        CreateMap<CreateProjectDto, Project>();
        CreateMap<Project, ReadProjectDto>();
    }

}
