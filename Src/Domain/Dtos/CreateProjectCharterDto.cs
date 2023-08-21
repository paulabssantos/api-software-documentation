using System.ComponentModel.DataAnnotations;

namespace api_software_documentation.Src.Domain.Dtos;

public class CreateProjectCharterDto
{

    [Required(ErrorMessage = "Id do projeto é obrigatório")]
    public int ProjectId { get; set; }

    [Required(ErrorMessage = "Objetivo é obrigatório")]
    public string Goal { get; set; }

    [Required(ErrorMessage = "Gerente do projeto é obrigatório")]
    public string ProjectManager { get; set; }

    [Required(ErrorMessage = "Data de início é obrigatória")]
    public DateOnly StartDate { get; set; }

    [Required(ErrorMessage = "Data de fim é obrigatória")]
    public DateOnly EndDate { get; set; }
}
