using System.ComponentModel.DataAnnotations;

namespace api_software_documentation.Src.Domain.Entities;

public class UserRequirement : Requirements
{
    [Required]
    public string User { get; set; }
    public virtual ICollection<FunctionalRequirement_UserRequirement> FunctionalRequirements_UserRequirements { get; set; }
}
