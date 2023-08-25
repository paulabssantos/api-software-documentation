using System.ComponentModel.DataAnnotations;
using api_software_documentation.src.Domain.Entities;

namespace api_software_documentation.Src.Domain.Entities;

public class UserRequirement
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int ProjectId { get; set; }

    [Required]
    public virtual Project Project { get; set; }

    [Required]
    public int Sequential { get; set; } = 1;

    [Required]
    public string Description { get; set; }

    [Required]
    public string User { get; set; }
    public virtual ICollection<FunctionalRequirement_UserRequirement> FunctionalRequirements_UserRequirements { get; set; }
}
