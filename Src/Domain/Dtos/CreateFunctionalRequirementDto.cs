using System.ComponentModel.DataAnnotations;
using api_software_documentation.Src.Domain.Enums;

public class CreateFunctionalRequirementDto
{
    [Required(ErrorMessage = "Descrição é obrigatória")]
    public string Description { get; set; }

    [Required(ErrorMessage = "Ator é obrigatório")]
    public string Actor { get; set; }

    [Required(ErrorMessage = "Prioridade é obrigatória")]
    [EnumDataType(typeof(Priority), ErrorMessage = "Prioridade precisa ser 1 (Essencial), 2 (Importante) ou 3 (Crítico)")]
    public Priority Priority { get; set; }
}