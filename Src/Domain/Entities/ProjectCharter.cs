using System.ComponentModel.DataAnnotations;

namespace api_software_documentation.src.Domain.Entities;

public class ProjectCharter
{
    [Key]
    public int Id { get; set; }


    [Required]
    public int ProjectId { get; set; }

    [Required]
    public virtual Project Project { get; set; }

    [Required]
    public string Goal { get; set; }

    [Required]
    public string ProjectManager { get; set; }

    [Required]
    public DateOnly StartDate { get; set; }

    [Required]
    public DateOnly EndDate { get; set; }

    [Required]
    public int Version { get; set; } = 1;

    [Required]
    public DateTime CreatedAt { get; set; } = DateTime.Now; 
}
