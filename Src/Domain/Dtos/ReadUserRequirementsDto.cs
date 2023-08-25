using System.ComponentModel.DataAnnotations;
using api_software_documentation.src.Domain.Entities;

namespace api_software_documentation.Src.Domain.Entities;

public class ReadUserRequirementDto
{
    public int Id { get; set; }
    public int ProjectId { get; set; }
    public int Sequential { get; set; } = 1;
    public string Description { get; set; }
    public string User { get; set; }
}
