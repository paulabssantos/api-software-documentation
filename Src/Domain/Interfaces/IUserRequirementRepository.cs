using api_software_documentation.Src.Domain.Entities;

public interface IUserRequirementRepository
{
    public List<UserRequirement> Create(List<UserRequirement> userRequirementDto);
    public List<UserRequirement> ListByProjectId(int ProjectId);
}