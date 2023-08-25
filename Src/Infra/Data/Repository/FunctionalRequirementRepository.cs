using api_software_documentation.src.Infra.Data.Context;
using api_software_documentation.Src.Domain.Entities;

public class FunctionalRequirementRepository : IFunctionalRequirementRepository
{
    private readonly MySqlContext _mySqlContext;
    public FunctionalRequirementRepository(MySqlContext mySqlContext)
    {
        _mySqlContext = mySqlContext;
    }
    public List<FunctionalRequirement> Create(List<FunctionalRequirement> functionalRequirement)
    {
        _mySqlContext.FunctionalRequirements.AddRange(functionalRequirement);
        _mySqlContext.SaveChanges();
        return functionalRequirement;
    }

    public FunctionalRequirement? FindLastByProjectId(int ProjectId)
    {
        var functionalRequirement = _mySqlContext.FunctionalRequirements.OrderByDescending(functionalRequirement => functionalRequirement.Sequential).FirstOrDefault(functionalRequirement => functionalRequirement.ProjectId == ProjectId);
        return functionalRequirement;
    }
}