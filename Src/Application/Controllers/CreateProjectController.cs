using api_software_documentation.src.Domain.Dtos;
using api_software_documentation.src.Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace api_software_documentation.src.Application.Controllers;

[ApiController]
[Route("/project")]
public class CreateProjectController : ControllerBase
{
    private readonly CreateProjectService _createProjectService;

    public CreateProjectController(CreateProjectService createProjectService)
    {
        _createProjectService = createProjectService;
    }

    [HttpPost]
    public IActionResult Handle([FromBody] CreateProjectDto dto)
    {
        var project = _createProjectService.Execute(dto);
        return Ok(project);
    }
}
