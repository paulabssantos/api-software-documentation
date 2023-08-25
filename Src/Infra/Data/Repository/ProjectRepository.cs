using api_software_documentation.src.Domain.Entities;
using api_software_documentation.src.Domain.Interfaces;
using api_software_documentation.src.Infra.Data.Context;

namespace api_software_documentation.src.Infra.Data.Repository;

public class ProjectRepository : IProjectRepository
{
    protected readonly MySqlContext _mySqlContext;

    public ProjectRepository(MySqlContext mySqlContext)
    {
        _mySqlContext = mySqlContext;
    }
    public Project Create(Project project)
    {
        _mySqlContext.Projects.Add(project);
        _mySqlContext.SaveChanges();

        return project;
    }

    public Project? FindById(int id)
    {
        var project = _mySqlContext.Projects.FirstOrDefault(_project => _project.Id == id);
        return project;
    }
}
