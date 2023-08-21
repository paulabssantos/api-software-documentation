using api_software_documentation.src.Domain.Entities;
using api_software_documentation.Src.Domain.Dtos;

namespace api_software_documentation.Src.Domain.Interfaces;

public interface IProjectCharterRepository
{
    public ProjectCharter Create(CreateProjectCharterDto createProjectCharterDto, int version);
    public ReadProjectCharterDto FindLastByProjectId(int projectId);

    public ReadProjectCharterDto FindById(int id);
}
