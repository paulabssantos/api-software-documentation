namespace api_software_documentation.src.Domain.Profile;
using api_software_documentation.src.Domain.Entities;
using api_software_documentation.Src.Domain.Dtos;
using AutoMapper;

public class ProjectCharterProfile : Profile
{
    public ProjectCharterProfile()
    {
        CreateMap<CreateProjectCharterDto, ProjectCharter>();
        CreateMap<ProjectCharter, ReadProjectCharterDto>().ForMember(projectCharterDto => projectCharterDto.Project, opt => opt.MapFrom(projectCharter => projectCharter.Project));
    }
}
