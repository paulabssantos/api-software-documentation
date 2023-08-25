using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("/functionalRequirements")]
[Tags("Functional Requirements")]
public class CreateFunctionalRequirementsController : ControllerBase
{
    private readonly CreateFunctionalRequirementsService _createFunctionalRequirementsService;

    public CreateFunctionalRequirementsController(CreateFunctionalRequirementsService createFunctionalRequirementsService)
    {
        _createFunctionalRequirementsService = createFunctionalRequirementsService;
    }

    [HttpPost("{ProjectId}")]
    public IActionResult Handle([FromBody] List<CreateFunctionalRequirementDto> dto, int ProjectId)
    {
        var (fuctionalRequirements, error) = _createFunctionalRequirementsService.Execute(dto, ProjectId);
        if (error != null)
        {
            return StatusCode(error.statusCode, error);
        }
        return Ok(fuctionalRequirements);
    }
}