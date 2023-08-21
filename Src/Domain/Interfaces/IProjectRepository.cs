using api_software_documentation.src.Domain.Dtos;
using api_software_documentation.src.Domain.Entities;
using api_software_documentation.Src.Domain.Dtos;

namespace api_software_documentation.src.Domain.Interfaces;

public interface IProjectRepository
{
    public Project Create(CreateProjectDto dto);
    public ReadProjectDto FindById(int id);
}
