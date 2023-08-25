using api_software_documentation.src.Domain.Dtos;
using api_software_documentation.src.Domain.Interfaces;
using api_software_documentation.Src.Application.Errors;
using api_software_documentation.Src.Domain.Entities;
using AutoMapper;

public class CreateUserRequirementsService
{
    private CreateRequirementsFactory _createRequirementsFactory;
    private readonly IUserRequirementRepository _userRequirementRepository;
    private readonly IProjectRepository _projectRepository;
    private readonly IMapper _mapper;
    public CreateUserRequirementsService(IMapper mapper, CreateRequirementsFactory createRequirementsFactory, IUserRequirementRepository userRequirementRepository, IProjectRepository projectRepository)
    {
        _userRequirementRepository = userRequirementRepository;
        _projectRepository = projectRepository;
        _mapper = mapper;
        _createRequirementsFactory = createRequirementsFactory;
    }

    public (List<ReadUserRequirementDto>?, ErrorResponse?) Execute(List<CreateUserRequirementDto> createUserRequirementDto, int ProjectId)
    {
        var project = _projectRepository.FindById(ProjectId);
        if (project == null)
        {
            return (null, new ErrorResponse("Projeto não encontrado", 404));
        }
        var userRequirements = _mapper.Map<List<UserRequirement>>(createUserRequirementDto);

        var sequential = 0;
        var lastUserRequirement = _userRequirementRepository.FindLastByProjectId(ProjectId);
        if (lastUserRequirement != null)
        {
            sequential = lastUserRequirement.Sequential;
        }
        _createRequirementsFactory.SetSequential(sequential, userRequirements);
        _createRequirementsFactory.SetProjectId(ProjectId, userRequirements);

        var createdUserRequirements = _mapper.Map<List<ReadUserRequirementDto>>(_userRequirementRepository.Create(userRequirements));
        return (createdUserRequirements, null);
    }
}