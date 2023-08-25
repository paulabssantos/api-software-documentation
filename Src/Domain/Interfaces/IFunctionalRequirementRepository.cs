using api_software_documentation.Src.Domain.Entities;

public interface IFunctionalRequirementRepository
{
    public List<FunctionalRequirement> Create(List<FunctionalRequirement> functionalRequirement);
    public FunctionalRequirement? FindLastByProjectId(int ProjectId);
}