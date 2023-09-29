using System.ComponentModel.DataAnnotations;

public class SendMailProjectCharterDto
{
    
    [Required(ErrorMessage = "Destinatário é obrigatório")]
    [EmailAddress(ErrorMessage = "Destinatário precisa ser um e-mail válido")]
    public string To;

    [Required(ErrorMessage = "Token único de acesso para usuário é obrigatório")]
    public string Token;
    
    [Required(ErrorMessage = "Nome do projeto é obrigatório")]
    public string ProjectName;

}