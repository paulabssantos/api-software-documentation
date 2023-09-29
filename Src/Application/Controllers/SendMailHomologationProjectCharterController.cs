using Microsoft.AspNetCore.Mvc;
namespace api_software_documentation.Src.Application.Controllers;

[ApiController]
[Route("/sendMailHomologation")]
public class SendMailHomologationProjectCharterController : ControllerBase
{

    private readonly SendMailHomologationProjectCharterService _sendMailHomologationProjectCharterService;
    public SendMailHomologationProjectCharterController(SendMailHomologationProjectCharterService sendMailHomologationProjectCharterService){
        _sendMailHomologationProjectCharterService = sendMailHomologationProjectCharterService;
    }   

    [HttpPost("{ProjectCharterId}")]
    public IActionResult Handle([FromBody] string clientMail, int ProjectCharterId){
        var (message, error) = _sendMailHomologationProjectCharterService.Execute(ProjectCharterId,clientMail);
        
        if(error != null){
            return StatusCode(error.statusCode,error);
        }
        return Ok(message);
    }
}