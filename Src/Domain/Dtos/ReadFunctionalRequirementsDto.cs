using api_software_documentation.Src.Domain.Enums;

public class ReadFunctionalRequirementDto
{
    public int Id { get; set; }

    public int ProjectId { get; set; }

    public int Sequential { get; set; }

    public string Description { get; set; }

    public string Actor { get; set; }

    public Priority Priority { get; set; }

}