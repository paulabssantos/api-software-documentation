using api_software_documentation.src.Domain.Interfaces;
using api_software_documentation.Src.Application.Errors;
using api_software_documentation.Src.Domain.Entities;
using AutoMapper;

public class CreateFunctionalRequirementsService
{
    private readonly IFunctionalRequirementRepository _functionalRequirementRepository;
    private readonly IProjectRepository _projectRepository;
    private readonly IMapper _mapper;
    public CreateFunctionalRequirementsService(IMapper mapper, IFunctionalRequirementRepository functionalRequirementRepository, IProjectRepository projectRepository)
    {
        _functionalRequirementRepository = functionalRequirementRepository;
        _projectRepository = projectRepository;
        _mapper = mapper;
    }

    public (List<ReadFunctionalRequirementDto>?, ErrorResponse?) Execute(List<CreateFunctionalRequirementDto> createFunctionalRequirementDto, int ProjectId)
    {
        var project = _projectRepository.FindById(ProjectId);
        if (project == null)
        {
            return (null, new ErrorResponse("Projeto não encontrado", 404));
        }
        var functionalRequirements = _mapper.Map<List<FunctionalRequirement>>(createFunctionalRequirementDto);

        var sequential = 0;
        var lastFunctionalRequirement = _functionalRequirementRepository.FindLastByProjectId(ProjectId);
        if (lastFunctionalRequirement != null)
        {
            sequential = lastFunctionalRequirement.Sequential;
        }
        functionalRequirements.ForEach(functionalRequirement =>
        {
            sequential = sequential + 1;
            functionalRequirement.Sequential = sequential;
            functionalRequirement.ProjectId = ProjectId;
        });
        var createdFunctionalRequirements = _mapper.Map<List<ReadFunctionalRequirementDto>>(_functionalRequirementRepository.Create(functionalRequirements));
        return (createdFunctionalRequirements, null);
    }
}