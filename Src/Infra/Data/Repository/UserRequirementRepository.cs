using api_software_documentation.src.Infra.Data.Context;
using api_software_documentation.Src.Domain.Entities;
using AutoMapper;

public class UserRequirementRepository : IUserRequirementRepository
{
    private readonly MySqlContext _mySqlContext;

    public UserRequirementRepository(MySqlContext mySqlContext, IMapper mapper)
    {
        _mySqlContext = mySqlContext;
    }
    public List<UserRequirement> Create(List<UserRequirement> userRequirements)
    {
        _mySqlContext.UserRequirements.AddRange(userRequirements);
        _mySqlContext.SaveChanges();
        return userRequirements;
    }

    public UserRequirement? FindLastByProjectId(int ProjectId)
    {
        var userRequirement = _mySqlContext.UserRequirements.OrderByDescending(userRequirement => userRequirement.Sequential).FirstOrDefault(userRequirement => userRequirement.ProjectId == ProjectId);
        return userRequirement;
    }

    public List<UserRequirement> ListByProjectId(int ProjectId)
    {
        var userRequirements = _mySqlContext.UserRequirements.Where(userRequirements => userRequirements.ProjectId == ProjectId).ToList();
        return userRequirements;
    }
}