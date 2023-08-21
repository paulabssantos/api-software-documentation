using System.ComponentModel.DataAnnotations;

namespace api_software_documentation.Src.Domain.Dtos;

public class ReadProjectCharterDto
{
    public int Id { get; set; }

    public ReadProjectDto Project { get; set; }

    public string Goal { get; set; }

    public string ProjectManager { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    public int Version { get; set; } = 1;

    public DateTime CreatedAt { get; set; } = DateTime.Now;
}
