using System.ComponentModel.DataAnnotations;

namespace api_software_documentation.src.Domain.Dtos;

public class CreateProjectDto
{
    [Required(ErrorMessage = "Nome do projeto é obrigatório")]
    [StringLength(50, ErrorMessage = "Nome do projeto pode ter no mázimo 50 caracteres")]
    public string Name { get; set; }
}
