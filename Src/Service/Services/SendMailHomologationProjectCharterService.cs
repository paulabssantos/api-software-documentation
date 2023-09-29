using System.ComponentModel.DataAnnotations;
using api_software_documentation.Src.Application.Errors;
using api_software_documentation.Src.Domain.Interfaces;

public class SendMailHomologationProjectCharterService
{
    private readonly IConfiguration _configuration;
    private readonly IProjectCharterRepository _projectCharterRepository;
    private readonly ITokenGenerator _tokenGenerator;
    public SendMailHomologationProjectCharterService(ITokenGenerator tokenGenerator,IConfiguration configuration, IProjectCharterRepository projectCharterRepository)
    {
        _configuration = configuration;
        _projectCharterRepository = projectCharterRepository;
        _tokenGenerator = tokenGenerator;

    }

    public (string?, ErrorResponse?) Execute([Required(ErrorMessage = "Id do termo de abertura é obrigatório")] int projectCharterId, [Required(ErrorMessage = "Email do cliente é obrigatório")] [EmailAddress(ErrorMessage = "E-mail do cliente precisa ser válido")] string clientMail)
    {
        var projectCharter = _projectCharterRepository.FindById(projectCharterId);

        if(projectCharter == null){
            return (null,new ErrorResponse("Termo de abertura de projeto não encontrado",404));
        }
        Mail mail = new(_configuration);
        var token = _tokenGenerator.GenerateMailToken(projectCharterId);
        SendMailProjectCharterDto mailData = new() { To = clientMail,ProjectName = projectCharter.Project.Name, Token = token};
        mail.SendMailProjectCharter(mailData);
        return ("E-mail enviado com sucesso",null);
    }
}