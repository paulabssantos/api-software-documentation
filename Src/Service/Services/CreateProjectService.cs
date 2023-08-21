using api_software_documentation.src.Domain.Dtos;
using api_software_documentation.src.Domain.Entities;
using api_software_documentation.src.Domain.Interfaces;
using api_software_documentation.Src.Domain.Dtos;

namespace api_software_documentation.src.Service.Services;

public class CreateProjectService
{

    private readonly IProjectRepository _projectRepository;

    public CreateProjectService(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }
    public ReadProjectDto Execute(CreateProjectDto dto)
    {
        var createdProject = _projectRepository.Create(dto);

        return _projectRepository.FindById(createdProject.Id);
    }
}
