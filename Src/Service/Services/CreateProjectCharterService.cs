using api_software_documentation.src.Domain.Entities;
using api_software_documentation.src.Domain.Interfaces;
using api_software_documentation.Src.Application.Errors;
using api_software_documentation.Src.Domain.Dtos;
using api_software_documentation.Src.Domain.Interfaces;
using AutoMapper;

namespace api_software_documentation.src.Service.Services;

public class CreateProjectCharterService
{
    private readonly IMapper _mapper;
    private readonly IProjectRepository _projectRepository;
    private readonly IProjectCharterRepository _projectCharterRepository;

    public CreateProjectCharterService(IMapper mapper, IProjectRepository projectRepository, IProjectCharterRepository projectCharterRepository)
    {
        _projectRepository = projectRepository;
        _projectCharterRepository = projectCharterRepository;
        _mapper = mapper;
    }

    public (ReadProjectCharterDto?, ErrorResponse?) Execute(CreateProjectCharterDto createProjectCharterDto)
    {
        var project = _projectRepository.FindById(createProjectCharterDto.ProjectId);

        if (project == null)
        {
            return (null, new ErrorResponse("Projeto não encontrado", 404));
        }

        var lastProjectCharter = _mapper.Map<ReadProjectCharterDto>(_projectCharterRepository.FindLastByProjectId(project.Id));

        var version = 1;
        if (lastProjectCharter != null)
        {
            version = lastProjectCharter.Version + 1;
        }

        var projectCharter = _mapper.Map<ProjectCharter>(createProjectCharterDto);
        projectCharter.Version = version;

        var createdProjectCharter = _projectCharterRepository.Create(projectCharter);
        return (_mapper.Map<ReadProjectCharterDto>(_projectCharterRepository.FindById(createdProjectCharter.Id)), null);
    }
}

