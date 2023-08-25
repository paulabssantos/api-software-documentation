using System.ComponentModel.DataAnnotations;
using api_software_documentation.src.Domain.Entities;

public class Requirements
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
}