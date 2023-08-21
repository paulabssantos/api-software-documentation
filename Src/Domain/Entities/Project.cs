using System.ComponentModel.DataAnnotations;
using api_software_documentation.Src.Domain.Entities;

namespace api_software_documentation.src.Domain.Entities;

public class Project
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public virtual ICollection<ProjectCharter> ProjectCharters { get; set; }
    public virtual ICollection<UserRequirement> UserRequirements { get; set; }
    public virtual ICollection<FunctionalRequirement> FunctionalRequirements { get; set; }
}
