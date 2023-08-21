using api_software_documentation.src.Domain.Entities;
using api_software_documentation.src.Infra.Data.Context;
using api_software_documentation.Src.Domain.Dtos;
using api_software_documentation.Src.Domain.Interfaces;
using AutoMapper;

namespace api_software_documentation.src.Infra.Data.Repository;

public class ProjectCharterRepository : IProjectCharterRepository
{
    private readonly MySqlContext _mySqlContext;
    private readonly IMapper _mapper;
    public ProjectCharterRepository(MySqlContext mySqlContext, IMapper mapper)
    {
        _mySqlContext = mySqlContext;
        _mapper = mapper;
    }

    public ProjectCharter Create(CreateProjectCharterDto createProjectCharterDto, int version)
    {
        var projectCharter = _mapper.Map<ProjectCharter>(createProjectCharterDto);
        projectCharter.Version = version;
        _mySqlContext.ProjectCharters.Add(projectCharter);
        _mySqlContext.SaveChanges();
        return projectCharter;
    }

    public ReadProjectCharterDto FindLastByProjectId(int projectId)
    {
        var projectCharter = _mySqlContext.ProjectCharters.OrderByDescending(projectCharter => projectCharter.Version).FirstOrDefault(projectCharter => projectCharter.ProjectId == projectId);

        return _mapper.Map<ReadProjectCharterDto>(projectCharter);
         
    }

    public ReadProjectCharterDto FindById(int id)
    {
        var projectCharter = _mySqlContext.ProjectCharters.FirstOrDefault(projectCharter => projectCharter.Id == id);
        return _mapper.Map<ReadProjectCharterDto>(projectCharter);
    }

}
