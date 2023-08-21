using System.ComponentModel.DataAnnotations;

namespace api_software_documentation.Src.Domain.Entities;

public class FunctionalRequirement_UserRequirement
{
    [Key]
    public int Id { get; set; }
    public int FunctionalRequirementId { get; set; }
    public virtual FunctionalRequirement FunctionalRequirement { get; set; }

    public int UserRequirementId { get; set; }
    public virtual UserRequirement UserRequirement{ get; set; }
}
