namespace api_software_documentation.src.Domain.Profile;

using api_software_documentation.Src.Domain.Entities;
using AutoMapper;
public class FunctionalRequirementProfile : Profile
{
    public FunctionalRequirementProfile()
    {
        CreateMap<CreateFunctionalRequirementDto, FunctionalRequirement>();
        CreateMap<FunctionalRequirement, ReadFunctionalRequirementDto>();
    }

}
