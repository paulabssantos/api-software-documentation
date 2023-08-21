using api_software_documentation.src.Domain.Dtos;
using api_software_documentation.src.Domain.Entities;
using api_software_documentation.src.Domain.Interfaces;
using api_software_documentation.src.Infra.Data.Context;
using api_software_documentation.Src.Domain.Dtos;
using AutoMapper;

namespace api_software_documentation.src.Infra.Data.Repository;

public class ProjectRepository : IProjectRepository
{
    protected readonly MySqlContext _mySqlContext;
    private IMapper _mapper;

    public ProjectRepository(MySqlContext mySqlContext, IMapper mapper)
    {
        _mySqlContext = mySqlContext;
        _mapper = mapper;
    }
    public Project Create(CreateProjectDto dto)
    {
        var project = _mapper.Map<Project>(dto);
        _mySqlContext.Projects.Add(project);
        _mySqlContext.SaveChanges();

        return project;
    }

    public ReadProjectDto FindById(int id)
    {
        var project = _mySqlContext.Projects.FirstOrDefault(_project => _project.Id == id);
        return _mapper.Map<ReadProjectDto>(project);
    }
}
