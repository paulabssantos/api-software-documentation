using api_software_documentation.src.Domain.Entities;

namespace api_software_documentation.src.Domain.Interfaces;

public interface IProjectRepository
{
    public Project Create(Project project);
    public Project? FindById(int id);
}
