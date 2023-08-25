using api_software_documentation.src.Domain.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace api_software_documentation.Src.Application.Controllers;

[ApiController]
[Route("/userRequirements")]
[Tags("User Requirements")]
public class CreateUserRequirementsController : ControllerBase
{
    private readonly CreateUserRequirementsService _createUserRequirementsService;

    public CreateUserRequirementsController(CreateUserRequirementsService createUserRequirementsService)
    {
        _createUserRequirementsService = createUserRequirementsService;
    }

    [HttpPost("{ProjectId}")]
    public IActionResult Handle([FromBody] List<CreateUserRequirementDto> dto, int ProjectId)
    {
        var (userRequirements, error) = _createUserRequirementsService.Execute(dto, ProjectId);
        if (error != null)
        {
            return StatusCode(error.statusCode, error);
        }
        return Ok(userRequirements);
    }
}
