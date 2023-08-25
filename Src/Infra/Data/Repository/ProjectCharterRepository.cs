using api_software_documentation.src.Domain.Entities;
using api_software_documentation.src.Infra.Data.Context;
using api_software_documentation.Src.Domain.Dtos;
using api_software_documentation.Src.Domain.Interfaces;
using AutoMapper;

namespace api_software_documentation.src.Infra.Data.Repository;

public class ProjectCharterRepository : IProjectCharterRepository
{
    private readonly MySqlContext _mySqlContext;
    public ProjectCharterRepository(MySqlContext mySqlContext, IMapper mapper)
    {
        _mySqlContext = mySqlContext;
    }

    public ProjectCharter Create(ProjectCharter projectCharter)
    {
        _mySqlContext.ProjectCharters.Add(projectCharter);
        _mySqlContext.SaveChanges();
        return projectCharter;
    }

    public ProjectCharter? FindLastByProjectId(int projectId)
    {
        var projectCharter = _mySqlContext.ProjectCharters.OrderByDescending(projectCharter => projectCharter.Version).FirstOrDefault(projectCharter => projectCharter.ProjectId == projectId);

        return projectCharter;

    }

    public ProjectCharter? FindById(int id)
    {
        var projectCharter = _mySqlContext.ProjectCharters.FirstOrDefault(projectCharter => projectCharter.Id == id);
        return projectCharter;
    }

}
