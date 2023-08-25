using System.ComponentModel.DataAnnotations;
using api_software_documentation.src.Domain.Entities;
using api_software_documentation.Src.Domain.Enums;

namespace api_software_documentation.Src.Domain.Entities;

public class FunctionalRequirement : Requirements
{
    [Required]
    public string Actor { get; set; }

    [EnumDataType(typeof(Priority), ErrorMessage = "Prioridade precisa ser 1 (Essencial), 2 (Importante) ou 3 (Crítico)")]
    public Priority Priority { get; set; }

    public virtual ICollection<FunctionalRequirement_UserRequirement> FunctionalRequirements_UserRequirements { get; set; }
}
