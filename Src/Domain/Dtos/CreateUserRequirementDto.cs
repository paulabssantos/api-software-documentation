using System.ComponentModel.DataAnnotations;

namespace api_software_documentation.src.Domain.Dtos;


public class CreateUserRequirementDto
{
    [Required(ErrorMessage = "Descrição é obrigatório")]
    public string Description { get; set; }

    [Required(ErrorMessage = "Usuário é obrigatório")]
    public string User { get; set; }

}
