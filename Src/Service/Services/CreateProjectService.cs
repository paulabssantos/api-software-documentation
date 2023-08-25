using api_software_documentation.src.Domain.Dtos;
using api_software_documentation.src.Domain.Entities;
using api_software_documentation.src.Domain.Interfaces;
using api_software_documentation.Src.Domain.Dtos;
using AutoMapper;

namespace api_software_documentation.src.Service.Services;

public class CreateProjectService
{
    private readonly IMapper _mapper;

    private readonly IProjectRepository _projectRepository;

    public CreateProjectService(IProjectRepository projectRepository, IMapper mapper)
    {
        _projectRepository = projectRepository;
        _mapper = mapper;
    }
    public ReadProjectDto Execute(CreateProjectDto createProjectDto)
    {
        var project = _mapper.Map<Project>(createProjectDto);
        _projectRepository.Create(project);
        return _mapper.Map<ReadProjectDto>(_projectRepository.FindById(project.Id));
    }
}
