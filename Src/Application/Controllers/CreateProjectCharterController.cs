using api_software_documentation.src.Service.Services;
using api_software_documentation.Src.Domain.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace api_software_documentation.Src.Application.Controllers;

[ApiController]
[Route("/projectCharter")]
[Tags("Project Charter")]
public class CreateProjectCharterController : ControllerBase
{
    private readonly CreateProjectCharterService _createProjectCharterService;

    public CreateProjectCharterController(CreateProjectCharterService createProjectCharterService)
    {
        _createProjectCharterService = createProjectCharterService;
    }

    [HttpPost]
    public IActionResult Handle([FromBody] CreateProjectCharterDto dto)
    {
        var (projectCharter, error) = _createProjectCharterService.Execute(dto);
        if (error != null)
        {
            return StatusCode(error.statusCode, error);
        }
        return Ok(projectCharter);
    }
}
