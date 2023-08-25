using api_software_documentation.src.Domain.Interfaces;
using api_software_documentation.Src.Application.Errors;
using api_software_documentation.Src.Domain.Entities;
using AutoMapper;

public class CreateFunctionalRequirementsService
{
    private CreateRequirementsFactory _createRequirementsFactory;
    private readonly IFunctionalRequirementRepository _functionalRequirementRepository;
    private readonly IProjectRepository _projectRepository;
    private readonly IMapper _mapper;
    public CreateFunctionalRequirementsService(IMapper mapper, CreateRequirementsFactory createRequirementsFactory, IFunctionalRequirementRepository functionalRequirementRepository, IProjectRepository projectRepository)
    {
        _functionalRequirementRepository = functionalRequirementRepository;
        _projectRepository = projectRepository;
        _mapper = mapper;
        _createRequirementsFactory = createRequirementsFactory;
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
        _createRequirementsFactory.SetSequential(sequential, functionalRequirements);
        _createRequirementsFactory.SetProjectId(ProjectId, functionalRequirements);

        var createdFunctionalRequirements = _mapper.Map<List<ReadFunctionalRequirementDto>>(_functionalRequirementRepository.Create(functionalRequirements));
        return (createdFunctionalRequirements, null);
    }
}