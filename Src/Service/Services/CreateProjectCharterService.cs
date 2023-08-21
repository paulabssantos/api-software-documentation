using System;
using api_software_documentation.src.Domain.Entities;
using api_software_documentation.src.Domain.Interfaces;
using api_software_documentation.Src.Application.Errors;
using api_software_documentation.Src.Domain.Dtos;
using api_software_documentation.Src.Domain.Interfaces;
using Castle.Components.DictionaryAdapter.Xml;
using Newtonsoft.Json;

namespace api_software_documentation.src.Service.Services;

public class CreateProjectCharterService
{
    private readonly IProjectRepository _projectRepository;
    private readonly IProjectCharterRepository _projectCharterRepository;

    public CreateProjectCharterService(IProjectRepository projectRepository, IProjectCharterRepository projectCharterRepository)
    {
        _projectRepository = projectRepository;
        _projectCharterRepository = projectCharterRepository;
    }

    public (ReadProjectCharterDto?,ErrorResponse?) Execute(CreateProjectCharterDto dto) 
    {
        var project = _projectRepository.FindById(dto.ProjectId);

        if(project == null)
        {
            return (null, new ErrorResponse("Projeto não encontrado", 404));
        }

        var lastProjectCharter = _projectCharterRepository.FindLastByProjectId(project.Id);

        var version = 1;
        if(lastProjectCharter != null) 
        {
            version = lastProjectCharter.Version + 1;
        }

        var createdProjectCharter = _projectCharterRepository.Create(dto, version);

        return (_projectCharterRepository.FindById(createdProjectCharter.Id),null);
    }
}

