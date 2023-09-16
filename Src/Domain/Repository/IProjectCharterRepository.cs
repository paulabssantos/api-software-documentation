using api_software_documentation.src.Domain.Entities;

namespace api_software_documentation.Src.Domain.Interfaces;

public interface IProjectCharterRepository
{
    public ProjectCharter Create(ProjectCharter projectCharter);
    public ProjectCharter? FindLastByProjectId(int projectId);

    public ProjectCharter? FindById(int id);
}
